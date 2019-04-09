using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace com.tdb.echo
{
    public class EchoLogConsoleWindow : EditorWindow
    {


        [MenuItem("Echo/OpenLogWindow")]
        public static void Init()
        {
            //创建窗口
            var window =
                (EchoLogConsoleWindow) GetWindow(typeof(EchoLogConsoleWindow), false, "Echo Console");
            window.minSize = new Vector2(300f, 150f);
            window._logHandler = EchoManager.Instance.GetLogHandler<EchoUILogHandler>();
            window._logHandler.LoadDefaultFilter();
            window.Show();
        }

        public void SetFilterDeleteFlag(int index)
        {
            
        }

        private void OnGUI()
        {
            if (_midSplitView == null)
                _midSplitView = new EditorGUISplitView(EditorGUISplitView.Direction.Horizontal, _SetNeedRepaint);

            if (_logSplitView == null)
                _logSplitView = new EditorGUISplitView(EditorGUISplitView.Direction.Vertical, _SetNeedRepaint);

            EditorGUILayout.BeginHorizontal();
            _midSplitView.BeginSplitView();

            _DrawLeftGroupView();

            _midSplitView.Split();

            _DrawRightGroupView();

            _midSplitView.EndSplitView();

            EditorGUILayout.EndHorizontal();
            
            _RepaintIfNeed();
        }

        private void _DrawLeftGroupView()
        {
            // left
            EditorGUILayout.BeginVertical(GUILayout.ExpandWidth(true));

            // Header
            EditorGUILayout.BeginHorizontal(GUILayout.Height(_headerHeight));

            GUILayout.Label("Fliter List:");
            GUILayout.FlexibleSpace();
            
            if (GUILayout.Button("Load Fliter"))
            {
                
            }
            
            if (GUILayout.Button("Add Fliter"))
            {
                AddFliterWindow.Open((filter) =>
                {
                    _logHandler.GetFilterList().Add(filter);
                });
            }

            EditorGUILayout.Space();
            EditorGUILayout.EndHorizontal();

            // scroll view
            _filterListScrollViewPosition = GUILayout.BeginScrollView(_filterListScrollViewPosition,
                EditorStyles.helpBox,
                GUILayout.ExpandHeight(true));

            FilterListView.Draw(_logHandler, ref _currentSelectedFilterIndex);

            // scroll view end
            EditorGUILayout.EndScrollView();

            // left end
            EditorGUILayout.EndVertical();
        }

        private void _DrawRightGroupView()
        {
            //EditorGUILayout.Space();
            _logSplitView.BeginSplitView();

            // header
            EditorGUILayout.BeginHorizontal(GUILayout.Height(_headerHeight));
            EditorGUILayout.Space();
            if (GUILayout.Button("Clear", EditorStyles.toolbarButton, GUILayout.Width(_rightGroupHeaderButtonWidth)))
            {
            }

            GUILayout.FlexibleSpace();
            _isShowError = GUILayout.Toggle(_isShowError, "Error", EditorStyles.toolbarButton,
                GUILayout.Width(_rightGroupHeaderButtonWidth));
            _isShowLog = GUILayout.Toggle(_isShowLog, "Log", EditorStyles.toolbarButton,
                GUILayout.Width(_rightGroupHeaderButtonWidth));
            _isShowWarning = GUILayout.Toggle(_isShowWarning, "Warning", EditorStyles.toolbarButton,
                GUILayout.Width(_rightGroupHeaderButtonWidth));

            // header end
            EditorGUILayout.EndHorizontal();


            // scroll view
            _logListScrollViewPosition = GUILayout.BeginScrollView(_logListScrollViewPosition,
                EditorStyles.helpBox,
                GUILayout.ExpandHeight(true));

            // Log List content
            if (GUILayout.Button("Add Fliter"))
            {
            }

            // scroll view end
            EditorGUILayout.EndScrollView();


            _logSplitView.Split();
//            EditorGUILayout.Space();
//            EditorGUILayout.Space();
            GUILayout.TextArea(_currentShowLogText);

            _logSplitView.EndSplitView();
            
        }

        private void _SetNeedRepaint()
        {
            _needRepaint = true;
        }

        private void _RepaintIfNeed()
        {
            if (_needRepaint)
            {
                Repaint();
                _needRepaint = false;
            }
        }
        
        private readonly float _headerHeight = 30f;
        
        private int _currentSelectedFilterIndex = 0;
        // right group param
        private readonly float _rightGroupHeaderButtonWidth = 80f;

        private readonly float _separatorLength = 5f;

        private readonly float _spliterWidth = 5f;

        private readonly string _currentShowLogText = "";

        private Vector2 _filterListScrollViewPosition = new Vector2(0, 0);

        private bool _needRepaint = true;

        private EchoUILogHandler _logHandler;

        // Log Level Button
        private bool _isShowError,_isShowLog, _isShowWarning;

        private Vector2 _logListScrollViewPosition = new Vector2(0, 0);

        private EditorGUISplitView _midSplitView, _logSplitView;
    }
}