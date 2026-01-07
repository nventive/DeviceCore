using System.Threading.Tasks;

namespace DeviceCore;

/// <summary>
/// Provides access to the device's flashlight functionality.
/// </summary>
public interface IFlashlightService
{
	/// <summary>
	/// Gets or sets the brightness of the flashlight with a value in the [0.0, 1.0] range.
	/// </summary>
	/// <remarks>
	/// On Android, flashlight brightness cannot be controlled, hence any non-zero BrightnessLevel results in the full brightness of the flashlight.
	/// On iOS, in case the device supports the torch, BrightnessLevel is fully supported. In case the device has only flash, any non-zero BrightnessLevel will result in the full brightness of the flashlight.
	/// </remarks>
	float Brightness { get; set; }

	/// <summary>
	/// Initializes the flashlight service.
	/// </summary>
	Task Initialize();

	/// <summary>
	/// Toggles the flashlight state on or off.
	/// </summary>
	/// <remarks>
	/// You must set the <see cref="Brightness"/> property before or after calling this method to ensure the desired brightness level is applied when the flashlight is turned on.
	/// </remarks>
	void Toggle();
}
