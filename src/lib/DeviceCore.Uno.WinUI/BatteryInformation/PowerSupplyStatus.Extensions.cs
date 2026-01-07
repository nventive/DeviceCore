#if ANDROID || IOS || WINDOWS
using System;

namespace Windows.System.Power;

internal static class PowerSupplyStatusExtensions
{
	/// <summary>
	/// Converts the <see cref="PowerSupplyStatus"/> to <see cref="DeviceCore.PowerSupplyStatus"/>.
	/// </summary>
	/// <param name="status">The power supply status.</param>
	/// <returns>The mapped <see cref="DeviceCore.PowerSupplyStatus"/>.</returns>
	public static DeviceCore.PowerSupplyStatus ToInternalPowerSupplyStatus(this PowerSupplyStatus status)
	{
		return status switch
		{
			PowerSupplyStatus.NotPresent => DeviceCore.PowerSupplyStatus.NotPresent,
			PowerSupplyStatus.Inadequate => DeviceCore.PowerSupplyStatus.Inadequate,
			PowerSupplyStatus.Adequate => DeviceCore.PowerSupplyStatus.Adequate,
			_ => throw new ArgumentOutOfRangeException(nameof(status), status, "Unknown power supply status."),
		};
	}
}
#endif
