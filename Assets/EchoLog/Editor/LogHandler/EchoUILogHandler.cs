using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace com.tdb.echo
{
    public class EchoUILogHandler : IEchoLogHandler
    {
        public void Log(EchoLogMessage logMessage)
        {
            _recordLogList.Add(logMessage);
        }

        public List<EchoFilter> GetFilterList()
        {
            if (_filters == null)
            {
                _filters = new List<EchoFilter>();
            }
            return _filters;
        }
        
        
        
        public void ClearAll()
        {
            
        }

        public void LoadDefaultFilter()
        {
            string echoRootPath = EchoEditorUtil.GetEchoRootPath();
            if (AssetDatabase.IsValidFolder(echoRootPath))
            {
                string defaultFilterFolderPath = echoRootPath+"/Editor/DefaultEchoFilter";
                if (!AssetDatabase.IsValidFolder(defaultFilterFolderPath))
                {
                    AssetDatabase.CreateFolder(echoRootPath+"/Editor", "DefaultEchoFilter");
                }

                var assetPaths = AssetDatabase.FindAssets("t:EchoFilter",new string[]{defaultFilterFolderPath});
                var filters = GetFilterList();
                foreach (var assetPath in assetPaths)
                {
                    var filter = AssetDatabase.LoadAssetAtPath<EchoFilter>(AssetDatabase.GUIDToAssetPath(assetPath));
                    if (filter != null && !filters.Contains(filter))
                    {
                        filters.Add(filter);
                    }
                }
            }
        }

        private List<EchoLogMessage> _recordLogList;

        private List<EchoFilter> _filters;

    }
}