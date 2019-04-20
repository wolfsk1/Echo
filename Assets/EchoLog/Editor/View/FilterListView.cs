using System.Collections.Generic;
using com.tdb.echo.Utils;
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
                    Rect box = EditorGUILayout.BeginHorizontal();
                    {
                        bool isSelected = i == selectedIndex;
                        Color backColor = isSelected ? Color.green : Color.white;
                        using (new GUIBackgroundColorScope(backColor))
                        {
                            bool click = GUI.Button(box, GUIContent.none, "Box");
                            if (click)
                            {
                                selectedIndex = i;
                            }
                            GUILayout.Box(filter.Name, GUILayout.ExpandWidth(true));
                            
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
    }
}