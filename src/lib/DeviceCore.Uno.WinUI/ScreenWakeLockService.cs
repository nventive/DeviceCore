#if ANDROID || IOS || WINDOWS
using System;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.UI.Dispatching;
using Windows.System.Display;

namespace DeviceCore;

/// <summary>
/// The <see cref="IScreenWakeLockService"/> implementation using Uno.
/// </summary>
public sealed class ScreenWakeLockService : IScreenWakeLockService, IDisposable
{
	private readonly ILogger _logger;
	private readonly DispatcherQueue _dispatcherQueue;

	private DisplayRequest? _displayRequest;
	private bool _isEnabled;

	public ScreenWakeLockService(ILogger<ScreenWakeLockService> logger, DispatcherQueue dispatcherQueue)
	{
		_logger = logger ?? NullLogger<ScreenWakeLockService>.Instance;
		_dispatcherQueue = dispatcherQueue ?? throw new ArgumentNullException(nameof(dispatcherQueue));
	}

	/// <inheritdoc/>
	public void Enable()
	{
		_logger.LogDebug("Trying to request display to stay active.");

		try
		{
			_dispatcherQueue.TryEnqueue(DispatcherQueuePriority.Normal, () =>
			{
				_displayRequest ??= new DisplayRequest();
				_displayRequest.RequestActive();
			});

			_isEnabled = true;
			_logger.LogInformation("Requested display to stay active.");
		}
		catch (Exception e)
		{
			_logger.LogError(e, "Failed to request display to stay active.");
			throw;
		}
	}

	/// <inheritdoc/>
	public void Disable()
	{
		_logger.LogDebug("Trying to release display request.");

		if (!_isEnabled)
		{
			_logger.LogWarning("Display request is already disabled.");
			return;
		}

		try
		{
			if (_displayRequest is null)
			{
				_logger.LogWarning("Display request is null, cannot release.");
				return;
			}

			_dispatcherQueue.TryEnqueue(DispatcherQueuePriority.Normal, _displayRequest!.RequestRelease);
			_isEnabled = false;
			_logger.LogInformation("Released display request.");
		}
		catch (Exception e)
		{
			_logger.LogError(e, "Failed to release display request.");
			throw;
		}
	}

	/// <inheritdoc/>
	public void Dispose()
	{
		if (_isEnabled)
		{
			Disable();
		}
	}
}
#endif
