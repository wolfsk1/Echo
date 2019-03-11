
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
            int i = 0;
            while (i < _logHandlers.Count)
            {
                var currentLogHandler = _logHandlers[i];
                if (currentLogHandler != null)
                {
                    currentLogHandler.Log(wlm);
                    i++;
                }
                else
                {
                    _logHandlers.RemoveAt(i);
                }
            }
        }

        public T AddLogHandler<T>() where T : class,IEchoLogHandler,new()
        {
            var type = typeof(T);
            
            if (!_logHandlers.Exists(data=>data.GetType() == type))
            {
                var logHandler = new T();
                _logHandlers.Add(logHandler);
                return logHandler;
            }
            else
            {
                Log(LogType.Warning, string.Format("try to add log handler:{0} failed.there already has one.", type.ToString()));
                return null;
            }
            
        }

        public void DeleteLogHandler<T>() where T : class,IEchoLogHandler,new()
        {
            var type = typeof(T);
            var result = _logHandlers.Find(data => data.GetType() == type);
            if (result != null)
            {
                _logHandlers.Remove(result);    
            }
            else
            {
                Log(LogType.Warning, string.Format("try to remove log handler:{0} failed.there no one.", type.ToString()));
            }
            
        }

        public T GetLogHandler<T>(bool isNeedCreate = true) where T : class, IEchoLogHandler, new()
        {
            var type = typeof(T);
            var result = (T)_logHandlers.Find(data=>data.GetType() == type);
            if (result != null)
            {
                return result;
            }
            else
            {
                return isNeedCreate ? AddLogHandler<T>() : null;
            }
        }

        public static void Reset()
        {
            _instance = new EchoManager();
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

        public bool OpenUnityLog
        {
            get { return _openUnityLog; }
            set
            {
                if (value == _openUnityLog) return;
                if (value)
                {
                    AddLogHandler<EchoUnityLogHandler>();
                }
                else
                {
                    DeleteLogHandler<EchoUnityLogHandler>();
                }

                _openUnityLog = value;

            }
        }

    }
}