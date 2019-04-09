using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

namespace com.tdb.echo
{
    public class FilterListView
    {
        public static void Draw(EchoUILogHandler logHandler, ref int selectedIndex)
        {
            var filters = logHandler.GetFilterList();
            int i = 0;
            while (i < filters.Count)
            {
                var filter = filters[i];
                if (filter == null)
                {
                    filters.RemoveAt(i);
                    if (i <= selectedIndex)
                    {
                        selectedIndex--;
                    }
                }
                else
                {
                    EditorGUILayout.BeginHorizontal();

                    if (GUILayout.Toggle(i == selectedIndex, filter.Name))
                    {
                        selectedIndex = i;
                    }

                    if (GUILayout.Button("Edit", GUILayout.Width(50)))
                    {
                        AddFliterWindow.Edit(filter);
                    }

                    if (GUILayout.Button("Save", GUILayout.Width(50)))
                    {
                    }

                    if (GUILayout.Button("X", GUILayout.Width(25)))
                    {
                        filters[i] = null;
                    }

                    EditorGUILayout.EndHorizontal();
                    EditorGUILayout.Space();
                    i++;
                }
            }
        }
    }
}