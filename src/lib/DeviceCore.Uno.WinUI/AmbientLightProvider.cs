#if ANDROID || IOS || WINDOWS
using System;
using System.Linq;
using System.Reactive.Linq;
using Windows.Devices.Sensors;
using Windows.Foundation;

namespace DeviceCore;

/// <summary>
/// The <see cref="IAmbientLightProvider"/> implementation using Uno.
/// </summary>
public sealed class AmbientLightProvider : IAmbientLightProvider
{
	private readonly LightSensor? _lightSensor;

	public AmbientLightProvider()
	{
		_lightSensor = LightSensor.GetDefault();
	}

	/// <inheritdoc/>
	public IObservable<AmbientLightReading?> ObserveCurrentReading()
	{
		if (_lightSensor is null)
		{
			return Observable.Return<AmbientLightReading?>(null);
		}

		return Observable.FromEventPattern<TypedEventHandler<LightSensor, LightSensorReadingChangedEventArgs>, LightSensorReadingChangedEventArgs>(
			h => _lightSensor.ReadingChanged += h,
			h => _lightSensor.ReadingChanged -= h
		)
		.Select(eventPattern =>
		{
			var reading = eventPattern.EventArgs.Reading;

			return new AmbientLightReading(
				reading.IlluminanceInLux,
				reading.PerformanceCount,
				reading.Properties,
				reading.Timestamp
			);
		});
	}
}
#endif
