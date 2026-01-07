using System;
using System.Reactive.Linq;

namespace DeviceCore;

/// <summary>
/// The fake implementation of <see cref="IAccelerometerService"/> for testing purposes.
/// </summary>
public sealed class FakeAccelerometerService : IAccelerometerService
{
	/// <inheritdoc/>
	public uint ReportInterval { get; set; }

	/// <inheritdoc/>
	public IObservable<AccelerometerReading?> ObserveAcceleration()
	{
		return Observable.Return<AccelerometerReading?>(new AccelerometerReading(0d, 0d, 0d, null, null, DateTimeOffset.Now));
	}

	/// <inheritdoc/>
	public IObservable<DateTimeOffset?> ObserveDeviceShaken()
	{
		return Observable.Return<DateTimeOffset?>(DateTimeOffset.Now);
	}
}
