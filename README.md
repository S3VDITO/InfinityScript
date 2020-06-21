# InfinityScript for IW5/TeknoMW3

Enhanced version of InfinityScript

## Prehistory

Unfortunately, this is decompiled InfinityScript by Slvr11, but there are some improvements(alse was refactoring)

## What I modified/added

* GetEntArray and SortByDistance can returns arrays, this was not achieved through in-game functions
* Endon function added
* Fix ControlsLinkTo
* GetField(fieldID, parameter) is static method and can be called out IS library
* WaitTill's can return parameters
* Coroutine class updated

## Todo
* Extend the basic capabilities of the Utilities class

## Small documentation

* WaitTill(string, Action<Parameter[]>);
```c#
private static void StartRoutine()
{
    StartAsync(UnknownFunction());
}

private static IEnumerator UnknownFunction()
{
    Parameter player = null;
    while (true)
    {
        yield return WaitTill("connected", args => player = args[0]);
        Utilities.PrintToConsole($"{player.As<Entity>().Name} connected!");
    }
}
```
* WaitTill(Action<string>, params string[]);
```c#
private static void StartRoutine()
{
    StartAsync(UnknownFunction());
}

private static IEnumerator UnknownFunction()
{
    string result = string.Empty;
    while (true)
    {
        yield return WaitTill(arg => result = arg, "disconnect", "death");
        Utilities.PrintToConsole(result);
    }
}
```

* BaseScript.StartAsync(IEnumerator, params string[]);
```c#
//  This is Endon
private static void StartRoutine()
{
    StartAsync(UnknownFunction(), "prematch_done");
}

private static IEnumerator UnknownFunction()
{
    while (true)
    {
        yield return WaitForFrame();
        Utilities.PrintToConsole("WaitForFrame()");
    }
}
```


