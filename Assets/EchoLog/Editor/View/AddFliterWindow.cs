using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

namespace com.tdb.echo
{
    public class AddFliterWindow : EditorWindow
    {
        public static void Open(UnityAction<EchoFilter> onComplete)
        {
            FocusWindowIfItsOpen(typeof(AddFliterWindow));
            Open(CreateInstance<EchoFilter>(), onComplete);
            
        }

        public static void Edit(EchoFilter filter)
        {
            Open(filter, null);
        }
        
        private static void Open(EchoFilter filter, UnityAction<EchoFilter> onComplete)
        {
            var window =
                (AddFliterWindow) GetWindow(typeof(AddFliterWindow), false, "Echo Filter");
            window.minSize = new Vector2(300f, 150f);
            window._onComplete = onComplete;
            window._filter = filter;
            window._name = window._filter.Name;
            window._tagString = window._filter.GetTags();
            window.Show();
        }
        

        private void OnGUI()
        {
            // total begin
            EditorGUILayout.BeginVertical();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Name:");
            _name = GUILayout.TextArea(_name);
            EditorGUILayout.EndHorizontal();
            
            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Tags(use ';' split):");
            _tagString = GUILayout.TextArea(_tagString);
            EditorGUILayout.EndHorizontal();
            
            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("Save"))
            {
                _filter.SetTags(_tagString);
                _filter.Name = _name;
                if (_onComplete != null)
                {
                    _onComplete.Invoke(_filter);    
                }
                Close();
            }
            EditorGUILayout.EndHorizontal();
            
            // total end
            EditorGUILayout.EndVertical();
        }


        private UnityAction<EchoFilter> _onComplete;
        private EchoFilter _filter;
        private string _name;
        private string _tagString;
    }
}