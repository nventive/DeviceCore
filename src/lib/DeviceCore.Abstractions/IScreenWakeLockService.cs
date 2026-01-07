namespace DeviceCore;

/// <summary>
/// Provides a way for keeping the device's display on.
/// </summary>
public interface IScreenWakeLockService
{
	/// <summary>
	/// Enables the device's keep screen on feature.
	/// </summary>
	void Enable();

	/// <summary>
	/// Disables the device's keep screen on feature.
	/// </summary>
	void Disable();
}
