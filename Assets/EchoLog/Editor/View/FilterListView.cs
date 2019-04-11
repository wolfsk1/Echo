using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.Events;

namespace com.tdb.echo
{
    public class FilterListView
    {
        public static void Draw(EchoUILogHandler logHandler, ref int selectedIndex)
        {
            if (logHandler == null) return;
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
                    bool isSelected = i == selectedIndex;
                    if (isSelected)
                    {
                        GUILayout.Label(filter.Name);
                    }
                    else
                    {
                        if (GUILayout.Button(filter.Name))
                        {
                            selectedIndex = i;
                        }
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