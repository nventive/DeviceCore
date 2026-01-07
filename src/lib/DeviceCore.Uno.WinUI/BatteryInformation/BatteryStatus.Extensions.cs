#if ANDROID || IOS || WINDOWS
using System;

namespace Windows.System.Power;

internal static class BatteryStatusExtensions
{
	/// <summary>
	/// Converts the <see cref="BatteryStatus"/> to <see cref="DeviceCore.BatteryStatus"/>.
	/// </summary>
	/// <param name="status">The battery status.</param>
	/// <returns>The mapped <see cref="DeviceCore.BatteryStatus"/>.</returns>
	public static DeviceCore.BatteryStatus ToInternalBatteryStatus(this BatteryStatus status)
	{
		return status switch
		{
			BatteryStatus.NotPresent => DeviceCore.BatteryStatus.NotPresent,
			BatteryStatus.Discharging => DeviceCore.BatteryStatus.Discharging,
			BatteryStatus.Idle => DeviceCore.BatteryStatus.Idle,
			BatteryStatus.Charging => DeviceCore.BatteryStatus.Charging,
			_ => throw new ArgumentOutOfRangeException(nameof(status), status, "Unknown battery status."),
		};
	}
}
#endif
