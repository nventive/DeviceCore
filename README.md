# Device Core

A cross-platform device services library for .NET 10+ and Uno Platform.

Device Core provides a unified API abstraction to access device hardware features such as accelerometer, ambient light sensor, battery information, flashlight, and screen wake lock across Windows, Android, and iOS.

[![License](https://img.shields.io/badge/License-Apache%202.0-blue.svg)](LICENSE)

## Getting Started

1. Add the `DeviceCore.Uno.WinUI` NuGet package to your projects (Windows, Android and iOS).
   > 💡 If you need to implement more platforms or create custom implementations, you can use the `DeviceCore.Abstractions` NuGet package.

1. Create an instance of any service. We'll cover dependency injection in details later on in this documentation.

   ```cs
   using DeviceCore;

   var flashlightService = new FlashlightService();
   ```

1. Use the service.

   ```cs
   flashlightService.Brightness = 0.5f;
   flashlightService.Toggle();
   ```

## Next Step

### Using Dependency Injection

Here is a simple code that does dependency injection using `Microsoft.Extensions.DependencyInjection` and `Microsoft.Extensions.Hosting`.

```cs
using DeviceCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
   .ConfigureServices(serviceCollection => serviceCollection
      .AddSingleton(_ => DispatcherQueue.GetForCurrentThread())
      .AddSingleton<IAccelerometerService, AccelerometerService>()
      .AddSingleton<IAmbientLightProvider, AmbientLightProvider>()
      .AddSingleton<IBatteryInformationProvider, BatteryInformationProvider>()
      .AddSingleton<IFlashlightService, FlashlightService>()
      .AddSingleton<IScreenWakeLockService, ScreenWakeLockService>()
   )
   .Build();
```

## Features

Now that everything is setup, Let's see what else we can do!

### Accelerometer

The `AccelerometerService` provides access to the device's accelerometer sensor, allowing you to read acceleration data in three dimensions (X, Y, Z).

> 💡 The `ObserveAcceleration` and `ObserveDeviceShaken` methods and will return an observable yielding `null` on devices that do not support `Accelerometer` or devices that do not have such a sensor.

> 💡 Unsubscribe from the `ObserveAcceleration` and `ObserveDeviceShaken` observables when you no longer need the readings to avoid unnecessary battery consumption.

> 💡 On iOS features built-in shake gesture recognition. Android use a common implementation to approximate shake detection. You can implement custom shake detection using the `ObserveAcceleration` method if needed.

> 💡 On Android, if both `ObserveAcceleration` and `ObserveDeviceShaken` observables are used and `ReportInterval` is set high, they may be yielding reading more often than requested due to multiple subscribers.

### Light Sensor

The `AmbientLightProvider` provides access to the device's ambient light sensor, allowing you to read the current light level.

> 💡 The `ObserveCurrentReading` method and will return an observable yielding `null` on devices that do not support `Accelerometer`, on devices that do not have such a sensor, or on iOS.

> 💡 Unsubscribe from the `ObserveCurrentReading` observable when you no longer need the readings to avoid unnecessary battery consumption.

### Battery Information

The `BatteryInformationProvider` provides access to the device's battery information, allowing you to read the current battery level and status.

> 💡 On Android, the `GetAndObserveRemainingChargePercent` observable is not updated continuously as there is no API that provides such events. It is triggered by system `Low` and `Ok` battery state broadcasts only. The `RemainingChargePercent` property always returns the up-to-date value. For continuous monitoring you can set up periodic polling.

#### Android

To use the battery information on Android, ensure you have the correct permissions in your `AndroidManifest.xml`.

```xml
<uses-permission android:name="android.permission.BATTERY_STATS" />
```

### Flashlight

The `FlashlightService` allows you to turn the phone's camera flashlight on and off.

> 💡 On Android, flashlight brightness cannot be controlled, hence any non-zero brightness level results in the full brightness of the flashlight.

> 💡 On iOS, in case the device supports the torch, brightness level is fully supported. In case the device has only flash, any non-zero brightness level will result in the full brightness of the flashlight.

#### Android

To use the flashlight on Android, ensure you have the correct permissions in your `AndroidManifest.xml`.

```xml
<uses-permission android:name="android.permission.FLASHLIGHT" />
<uses-permission android:name="android.permission.CAMERA" />
```

### Keeping Screen On

To enables an application to request to keep the device's screen on, use the `ScreenWakeLockService`.

## Acknowledgements

Take a look at [Uno.WinRT](https://platform.uno/docs/articles/features/using-winrt.html) that we use for the mobile platforms implementation.

## Breaking Changes

Please consult [BREAKING_CHANGES.md](BREAKING_CHANGES.md) for more information about version
history and compatibility.

## License

This project is licensed under the Apache 2.0 license - see the
[LICENSE](LICENSE) file for details.

## Contributing

Please read [CONTRIBUTING.md](CONTRIBUTING.md) for details on the process for
contributing to this project.

Be mindful of our [Code of Conduct](CODE_OF_CONDUCT.md).