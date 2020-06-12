# InfinityScript for TeknoMW3

Enhanced version of InfinityScript

## Prehistory

Unfortunately, this is decompiled InfinityScript by Slvr11, but there are some improvements(alse was refactoring)

## What I modified/added

* GetEntArray and SortByDistance can returns arrays, this was not achieved through in-game functions
* Endon function added
* Fix ControlsLinkTo
* GetField(fieldID, parameter) is static method and can be called out IS library

## Small documentation

* Coroutiune example

```c#
BaseScript.StartAsync(AsyncCode(), new string[] { "your endon notifies" });

public IEnumerator AsyncCode()
{
    while (true)
    {
        yield return BaseScript.WaitTill("prematch_done");
        Log.Info("Prematch done complited!");
        yield break;
    }
}
```
