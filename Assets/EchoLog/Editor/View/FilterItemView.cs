using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

namespace com.tdb.echo
{
    public class FilterItemView
    {
        public static void Draw(EchoFilter filter)
        {
            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button(filter.Name))
            {
                Debug.Log("Click"+filter.Name);
            }

            if (GUILayout.Button("Edit", GUILayout.Width(50)))
            {
                AddFliterWindow.Open(filter, (newFilter) => { filter = newFilter; });
            }
            EditorGUILayout.EndHorizontal();
        }
    }
}