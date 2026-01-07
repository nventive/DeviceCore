#if ANDROID || IOS || WINDOWS
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Reactive.Linq;
using Windows.Devices.Sensors;
using Windows.Foundation;

namespace DeviceCore;

/// <summary>
/// The <see cref="IAccelerometerService"/> implementation using Uno.
/// </summary>
public sealed class AccelerometerService : IAccelerometerService
{
	private readonly ILogger<AccelerometerService> _logger;
	private readonly Accelerometer? _accelerometer;

	public AccelerometerService(ILogger<AccelerometerService> logger)
	{
		_logger = logger ?? NullLogger<AccelerometerService>.Instance;
		_accelerometer = Accelerometer.GetDefault();
	}

	/// <inheritdoc/>
	public uint ReportInterval
	{
		get => _accelerometer?.ReportInterval ?? 0;
		set
		{
			if (_accelerometer is null)
			{
				return;
			}

			_accelerometer.ReportInterval = value;
		}
	}

	/// <inheritdoc/>
	public IObservable<AccelerometerReading?> ObserveAcceleration()
	{
		if (_accelerometer is null)
		{
			return Observable.Return<AccelerometerReading?>(null);
		}

		return Observable.FromEventPattern<TypedEventHandler<Accelerometer, AccelerometerReadingChangedEventArgs>, AccelerometerReadingChangedEventArgs>(
			h => _accelerometer.ReadingChanged += h,
			h => _accelerometer.ReadingChanged -= h
		)
		.Select(eventPattern =>
		{
			var reading = eventPattern.EventArgs.Reading;

			return new AccelerometerReading(
				reading.AccelerationX,
				reading.AccelerationY,
				reading.AccelerationZ,
				reading.PerformanceCount,
				reading.Properties,
				reading.Timestamp
			);
		});
	}

	/// <inheritdoc/>
	public IObservable<DateTimeOffset?> ObserveDeviceShaken()
	{
		if (_accelerometer is null)
		{
			return Observable.Return<DateTimeOffset?>(null);
		}

		return Observable.FromEventPattern<TypedEventHandler<Accelerometer, AccelerometerShakenEventArgs>, AccelerometerShakenEventArgs>(
			h => _accelerometer.Shaken += h,
			h => _accelerometer.Shaken -= h
		)
		.Select(eventPattern => (DateTimeOffset?)eventPattern.EventArgs.Timestamp);
	}
}
#endif
