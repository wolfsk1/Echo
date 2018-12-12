
using System.Diagnostics;
using com.tdb.w;
using UnityEngine;

public class WLogManager
{
    public void Log(LogType logType, string content, params string[] tags)
    {
        WLogMessage wlm = new WLogMessage(logType, content, tags);
        StackTrace st = new StackTrace(2, true);
        wlm.Trace = st;
    }

    private static WLogManager _instance;
    public static WLogManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new WLogManager();
            }

            return _instance;
        }
    }

    public IWLogHandler LogHandler;
}
