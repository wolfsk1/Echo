using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace com.tdb.echo
{
    public class EchoUILogHandler : IEchoLogHandler
    {
        public EchoUILogHandler()
        {
            if (string.IsNullOrEmpty(_echoEditorConfigFloderPath)||!Directory.Exists(_echoEditorConfigFloderPath))
            {
                _echoEditorConfigFloderPath = _FindEchoPath();
                if (_echoEditorConfigFloderPath == null)
                {
                    Echo.LogError("Can`t Find Floder 'EchoLog'.Please rename echo root floder name to 'EchoLog'");
                    return;
                }
            }
            
            
        }
        
        private static string _FindEchoPath()
        {
            string result = _FindFloder(Application.dataPath, "EchoLog"); 
            return result;
        }

        private static string _FindFloder(string rootPath, string floderName)
        {
            var paths = Directory.GetDirectories(rootPath);
            foreach (var childPath in paths)
            {
                string result = null;
                if (childPath.EndsWith(floderName))
                {
                    result = childPath;
                }
                else
                {
                    result = _FindFloder(childPath, floderName);
                }

                if (result != null)
                {
                    return result;
                }
            }

            return null;
        }
        public void Log(EchoMessage message)
        {
            _recordLogList.Add(message);
        }
        
        public void ClearAll()
        {
            
        }
        
        
        private List<EchoMessage> _recordLogList;

        private List<EchoFilter> _fliters;

        private string _echoEditorConfigFloderPath;
    }
}