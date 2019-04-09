
using System.Diagnostics;
using UnityEngine;

namespace com.tdb.echo
{
    public struct EchoLogMessage
    {
        public EchoLogMessage(LogType type, string content, params string[] tags)
        {
            Type = type;
            Content = content;
            Tags = tags;
            Trace = null;
        }

        public LogType Type;
        public string Content;
        public string[] Tags;
        public StackTrace Trace;
    }
}