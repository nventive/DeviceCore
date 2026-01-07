using System;
using System.Reactive.Linq;

namespace DeviceCore;

/// <summary>
/// Fake implementation of <see cref="IBatteryInformationProvider"/> for testing purposes.
/// </summary>
public sealed class FakeBatteryInformationProvider : IBatteryInformationProvider
{
	/// <inheritdoc/>
	public BatteryStatus BatteryStatus { get; }

	/// <inheritdoc/>
	public EnergySaverStatus EnergySaverStatus { get; }

	/// <inheritdoc/>
	public PowerSupplyStatus PowerSupplyStatus { get; }

	/// <inheritdoc/>
	public int RemainingChargePercent { get; }

	/// <inheritdoc/>
	public IObservable<BatteryStatus> GetAndObserveBatteryStatus()
	{
		return Observable.Return(BatteryStatus);
	}

	/// <inheritdoc/>
	public IObservable<EnergySaverStatus> GetAndObserveEnergySaverStatus()
	{
		return Observable.Return(EnergySaverStatus);
	}

	/// <inheritdoc/>
	public IObservable<PowerSupplyStatus> GetAndObservePowerSupplyStatus()
	{
		return Observable.Return(PowerSupplyStatus);
	}

	/// <inheritdoc/>
	public IObservable<int> GetAndObserveRemainingChargePercent()
	{
		return Observable.Return(RemainingChargePercent);
	}
}
