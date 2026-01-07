using System;

namespace DeviceCore;

/// <summary>
/// Provides access to the current ambient light (illuminance level) reading in lux and detects changes.
/// </summary>
/// <remarks>
/// The device or emulator that you're using must support an ambient light sensor.
/// </remarks>
public interface IAmbientLightProvider
{
	/// <summary>
	/// Observes the current ambient light reading.
	/// </summary>
	/// <remarks>
	/// If the device does not support an ambient light sensor, this method will return an observable sequence that yields null.
	/// </remarks>
	/// <returns>An observable sequence yielding the current ambient light reading.</returns>
	IObservable<AmbientLightReading?> ObserveCurrentReading();
}
