## RocketPluginHelper

[![NuGet](https://img.shields.io/nuget/v/RocketPluginHelper.svg)](https://www.nuget.org/packages/RocketPluginHelper/)
[![NuGet Downloads](https://img.shields.io/nuget/dt/RocketPluginHelper.svg)](https://www.nuget.org/packages/RocketPluginHelper/)

A tool that would help you with multi-threading, UniTask, Harmony, and many many more, without much things to do, this can be used for client Modules, OpenMod and RocketMod development.

### Usability

Not always OpenMod is a best choice to make a plugin for Unturned, so, then RocketMod is what we need, but `penMod have a lot of great features for threading, etc, but it's annoying to integrate all code to initialize UniTask (about ~100 new lines of code in Load of the plugin).

Sometimes you would probably need things to catch an exception when Unturned got updated and Harmony patches doesn't work anymore, and you don't get any exceptions, etc.

By default OpenMod initializes all of those simple things to simplify the plugin development, but what to do in case when the customer/user doesn't have installed OpenMod, and you need all of those features? You don't want to install OpenMod.Core or write extra lines of code? RocketPluginHelper's great solution for you in this case.

## Supported .NET Versions

[![.NET Standard](https://img.shields.io/badge/.NET%20Standard-2.0-brightgreen)](https://docs.microsoft.com/en-us/dotnet/standard/net-standard)
[![.NET Framework](https://img.shields.io/badge/.NET%20Framework-4.6.1-brightgreen)](https://dotnet.microsoft.com/download/dotnet-framework)

This project supports the following .NET versions:

- .NET Standard 2.0
- .NET Framework 4.6.1

Make sure you have the appropriate .NET version installed before using this project.

For more information about .NET Standard, please refer to the [official .NET Standard documentation](https://docs.microsoft.com/en-us/dotnet/standard/net-standard).

To download the .NET Framework 4.6.1, please visit the [official .NET Framework website](https://dotnet.microsoft.com/en-us/download/dotnet-framework/net461).

### Installation

> Select 1 way of provided installations

Package Manager:
````
Install-Package RocketPluginHelper
````

.NET CLI:
````
dotnet add package RocketPluginHelper
````

Find in the NuGet package manager of your IDE:
````
RocketPluginHelper
````

Grab the binaries (compile the solution):
1. Installed VS 2022/JetBrains Rider
2. Installed .NET Framework 461 + Dev Pack, and netstandard 2.0
3. Reference the .dll compiled files to your project (i.e `RocketPluginHelper.dll`)

## Credits

[OpenMod](https://github.com/openmod/openmod) for nuget packages ready-to-go actions and workflows.