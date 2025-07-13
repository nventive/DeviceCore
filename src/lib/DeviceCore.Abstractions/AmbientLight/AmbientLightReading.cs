using System;
using System.Collections.Generic;

namespace DeviceCore;

/// <summary>
/// Represents an ambient light–sensor reading.
/// </summary>
public sealed class AmbientLightReading
{
	public AmbientLightReading(
		float illuminanceInLux,
		TimeSpan? performanceCount,
		IReadOnlyDictionary<string, object>? properties,
		DateTimeOffset timestamp
	)
	{
		IlluminanceInLux = illuminanceInLux;
		PerformanceCount = performanceCount;
		Properties = properties;
		Timestamp = timestamp;
	}

	/// <summary>
	/// Gets the illuminance level in lux.
	/// </summary>
	public float IlluminanceInLux { get; }

	/// <summary>
	/// Gets the performance count associated with the reading.This allows the reading to be synchronized with other devices and processes on the system.
	/// </summary>
	public TimeSpan? PerformanceCount { get; }

	/// <summary>
	/// Gets the data properties reported by the sensor.
	/// </summary>
	public IReadOnlyDictionary<string, object>? Properties { get; }

	/// <summary>
	/// Gets the time at which the sensor reported the reading.
	/// </summary>
	public DateTimeOffset Timestamp { get; }
}
