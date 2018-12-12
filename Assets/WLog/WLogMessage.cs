
using System.Diagnostics;
using UnityEngine;

public class WLogMessage
{
    public WLogMessage(LogType type, string content, params string[] tags)
    {
        Type = type;
        Content = content;
        Tags = tags;
    }
    
    public LogType Type;
    public string Content;
    public string[] Tags;
    public StackTrace Trace;
}
