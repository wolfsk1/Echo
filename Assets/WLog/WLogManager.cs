
using System.Collections.Generic;
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
        _recordLogs.Add(wlm);
        foreach (var wLogHandler in _logHandlers)
        {
            wLogHandler.Log(wlm);
        }
    }

    private WLogManager()
    {
        _logHandlers = new List<IWLogHandler>();
        _recordLogs = new List<WLogMessage>();
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

    private List<IWLogHandler> _logHandlers;

    private List<WLogMessage> _recordLogs;
}
