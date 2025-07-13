using System;

namespace DeviceCore;

/// <summary>
/// Provides access to battery information on the device.
/// </summary>
public interface IBatteryInformationProvider
{
	/// <summary>
	/// Gets the device's battery status.
	/// </summary>
	BatteryStatus BatteryStatus { get; }

	/// <summary>
	/// Gets the devices's battery saver status, indicating when to save energy.
	/// </summary>
	EnergySaverStatus EnergySaverStatus { get; }

	/// <summary>
	/// Gets the device's power supply status.
	/// </summary>
	PowerSupplyStatus PowerSupplyStatus { get; }

	/// <summary>
	/// Gets the total percentage of charge remaining from all batteries connected to the device.
	/// </summary>
	int RemainingChargePercent { get; }

	/// <summary>
	/// Gets and observes the current battery status.
	/// </summary>
	/// <returns>An observable sequence yielding the curent battery status.</returns>
	IObservable<BatteryStatus> GetAndObserveBatteryStatus();

	/// <summary>
	/// Gets and observes the current energy saver status.
	/// </summary>
	/// <returns>An observable sequence yielding the curent energy saver status.</returns>
	IObservable<EnergySaverStatus> GetAndObserveEnergySaverStatus();

	/// <summary>
	/// Gets and observes the current power supply status.
	/// </summary>
	/// <returns>An observable sequence yielding the curent power supply status.</returns>
	IObservable<PowerSupplyStatus> GetAndObservePowerSupplyStatus();

	/// <summary>
	/// Gets and observes the remaining charge percentage from all batteries connected to the device.
	/// </summary>
	/// <returns>An observable sequence yielding the remaining charge time.</returns>
	IObservable<int> GetAndObserveRemainingChargePercent();
}
