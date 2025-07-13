#if ANDROID || IOS || WINDOWS
using System;

namespace Windows.System.Power;

internal static class EnergySaverStatusExtensions
{
	/// <summary>
	/// Converts the <see cref="EnergySaverStatus"/> to <see cref="DeviceCore.EnergySaverStatus"/>.
	/// </summary>
	/// <param name="status">The energy saver status.</param>
	/// <returns>The mapped <see cref="DeviceCore.EnergySaverStatus"/>.</returns>
	public static DeviceCore.EnergySaverStatus ToInternalEnergySaverStatus(this EnergySaverStatus status)
	{
		return status switch
		{
			EnergySaverStatus.Disabled => DeviceCore.EnergySaverStatus.Disabled,
			EnergySaverStatus.Off => DeviceCore.EnergySaverStatus.Off,
			EnergySaverStatus.On => DeviceCore.EnergySaverStatus.On,
			_ => throw new ArgumentOutOfRangeException(nameof(status), status, "Unknown energy saver status."),
		};
	}
}
#endif
