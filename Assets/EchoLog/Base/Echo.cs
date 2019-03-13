using com.tdb.echo;
using UnityEngine;

public class Echo {

    public static void LogError(string context, params string[] tags)
    {
        EchoManager.Instance.Log(LogType.Error, context, tags);
    }

    public static void LogWarning(string context, params string[] tags)
    {
        EchoManager.Instance.Log(LogType.Warning, context, tags);
    }

    public static void Log(string context, params string[] tags)
    {
        EchoManager.Instance.Log(LogType.Log, context, tags);
    }
}

