using System;
using System.Reactive.Linq;

namespace DeviceCore;

/// <summary>
/// The fake implementation of <see cref="IAmbientLightProvider"/> for testing purposes.
/// </summary>
public sealed class FakeAmbientLightProvider : IAmbientLightProvider
{
	/// <inheritdoc/>
	public IObservable<AmbientLightReading?> ObserveCurrentReading()
	{
		return Observable.Return(new AmbientLightReading(0f, null, null, DateTimeOffset.Now));
	}
}
