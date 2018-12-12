using System;
using System.Collections;
using System.Collections.Generic;
using com.tdb.w;
using UnityEngine;
using Object = UnityEngine.Object;

public class WLog {

    public static void LogError(string context, params string[] tags)
    {
        WLogManager.Instance.Log(LogType.Error, context, tags);
    }
    
    public static void LogWarning(string context, params string[] tags)
    {
        WLogManager.Instance.Log(LogType.Warning, context, tags);
    }
    
    public static void Log(string context, params string[] tags)
    {
        WLogManager.Instance.Log(LogType.Log, context, tags);
    }

}
