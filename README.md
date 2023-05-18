## RocketPluginHelper
A tool that would help you with multi-threading, UniTask, Harmony, and many many more, without much things to do, this can be used for client Modules, OpenMod and RocketMod development.

### Usability
Not always OpenMod is a best choice to make a plugin for Unturned, so, then RocketMod is what we need, but OpenMod have a lot of great features for threading, etc, but it's annoying to integrate all code to initialize UniTask (about ~100 new lines of code in Load of the plugin).

Sometimes you would probably need things to catch an exception when Unturned got updated and Harmony patches doesn't work anymore, and you don't get any exceptions, etc.

By default OpenMod initializes all of those simple things to simplify the plugin development, but what to do in case when the customer/user doesn't have installed OpenMod, and you need all of those features? You don't want to install OpenMod.Core or write extra lines of code? RocketPluginHelper's great solution for you in this case.

### Credits
[OpenMod](https://github.com/openmod/openmod) for nuget packages ready-to-go actions and workflows.