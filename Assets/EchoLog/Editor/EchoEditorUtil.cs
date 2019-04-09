using System.IO;
using UnityEngine;

namespace com.tdb.echo
{
    public class EchoEditorUtil
    {
        public static string GetEchoRootPath()
        {
            string result = _FindFolder(Application.dataPath, "EchoLog");
            if (result != null)
            {
                result = "Assets/"+result.Substring(Application.dataPath.Length+1);
            }
            return result;
        }

        private static string _FindFolder(string rootPath, string folderName)
        {
            var paths = Directory.GetDirectories(rootPath);
            foreach (var childPath in paths)
            {
                string result = null;
                if (childPath.EndsWith(folderName))
                {
                    result = childPath;
                }
                else
                {
                    result = _FindFolder(childPath, folderName);
                }

                if (result != null)
                {
                    return result;
                }
            }

            return null;
        }
    }
}