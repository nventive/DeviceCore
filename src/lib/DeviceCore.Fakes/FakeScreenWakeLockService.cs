namespace DeviceCore;

/// <summary>
/// The fake <see cref="IScreenWakeLockService"/> implementation for testing purposes.
/// </summary>
public sealed class FakeScreenWakeLockService : IScreenWakeLockService
{
	/// <inheritdoc/>
	public void Disable()
	{
		return;
	}

	/// <inheritdoc/>
	public void Enable()
	{
		return;
	}
}
