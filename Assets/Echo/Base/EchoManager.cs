
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace com.tdb.echo
{
    public class EchoManager
    {
        public void Log(LogType logType, string content, params string[] tags)
        {
            EchoMessage wlm = new EchoMessage(logType, content, tags);
            StackTrace st = new StackTrace(2, true);
            wlm.Trace = st;
            foreach (var eLogHandler in _logHandlers)
            {
                eLogHandler.Log(wlm);
            }
        }

        private EchoManager()
        {
            _logHandlers = new List<IEchoLogHandler>();
        }

        private static EchoManager _instance;

        public static EchoManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new EchoManager();
                }

                return _instance;
            }
        }

        private List<IEchoLogHandler> _logHandlers;

    }
}