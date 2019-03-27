using System.IO;
using Boo.Lang;
using com.tdb.echo;
using EchoLog.Editor;
using UnityEditor;
using UnityEngine;

public class EchoLogConsoleWindow : EditorWindow
{
    [MenuItem("Echo/OpenLogWindow")]
    public static void Init()
    {
        EchoManager.Instance.GetLogHandler<EchoUILogHandler>();
        //创建窗口
        EchoLogConsoleWindow window =
            (EchoLogConsoleWindow) GetWindow(typeof(EchoLogConsoleWindow), false, "WLog Console");
        window._init();
        window.Show();
    }

    private void _init()
    {
        _midSplitView = new EditorHorizontalSplitView();
        _midSplitView.Init(this, _OnMidResize);
    }
    void OnGUI()
    {
        var windowsHeight = position.height;
        var windowsWidth = position.width;
        EditorGUILayout.BeginHorizontal();
        _DrawLeftGroupView(windowsHeight);
        
        _midSplitView.Split(windowsWidth, windowsHeight);
        
        _DrawRightGroupView();
        EditorGUILayout.EndHorizontal();
    }

    private void _DrawLeftGroupView(float windowsHeight)
    {
        // left
        EditorGUILayout.BeginVertical(GUILayout.Width(_midSpliterPos));
        
        // Header
        EditorGUILayout.BeginHorizontal(GUILayout.Height(_headerHeight));
        
        GUILayout.Label("Fliter List:");
        
        if (GUILayout.Button("Add Fliter",GUILayout.Width(_rightGroupHeaderButtonWidth)))
        {
        }

        EditorGUILayout.EndHorizontal();

        // scroll view
        float scrollViewHeight = windowsHeight - _headerHeight;
        _filterListScrollViewPosition = GUILayout.BeginScrollView(_filterListScrollViewPosition,
            EditorStyles.helpBox,
            GUILayout.Height(scrollViewHeight));

        // filter List content
        if (GUILayout.Button("Add Fliter"))
        {
        }
        // scroll view end
        EditorGUILayout.EndScrollView();

        // left end
        EditorGUILayout.EndVertical();
    }

    private void _DrawRightGroupView()
    {
        // right
        EditorGUILayout.BeginVertical(GUILayout.ExpandWidth(true));
        
        // header
        EditorGUILayout.BeginHorizontal(GUILayout.Height(_headerHeight));
        
        if (GUILayout.Button("Clear", EditorStyles.toolbarButton, GUILayout.Width(_rightGroupHeaderButtonWidth)))
        {
            
        }
        GUILayout.FlexibleSpace();
        _isShowError = GUILayout.Toggle(_isShowError, "Error", EditorStyles.toolbarButton, GUILayout.Width(_rightGroupHeaderButtonWidth));
        _isShowLog = GUILayout.Toggle(_isShowLog, "Log", EditorStyles.toolbarButton, GUILayout.Width(_rightGroupHeaderButtonWidth));
        _isShowWarning = GUILayout.Toggle(_isShowWarning, "Warning", EditorStyles.toolbarButton, GUILayout.Width(_rightGroupHeaderButtonWidth));

        // header end
        EditorGUILayout.EndHorizontal();
        // scroll view
        _logListScrollViewPosition = GUILayout.BeginScrollView(_logListScrollViewPosition,
            EditorStyles.helpBox,
            GUILayout.ExpandHeight(true));

        // filter List content
        if (GUILayout.Button("Add Fliter"))
        {
        }
        // scroll view end
        EditorGUILayout.EndScrollView();
        
        // right end
        EditorGUILayout.EndVertical();
    }

    private void _OnMidResize(float x)
    {
        _midSpliterPos = x;
    }
    
    private readonly float _headerHeight = 30f;

    private readonly float _separatorLength = 5f;

    private readonly float _spliterWidth = 5f;

    // right group param
    private readonly float _rightGroupHeaderButtonWidth = 80f;
    
    
    // Log Level Button
    private bool _isShowWarning;
    private bool _isShowLog;
    private bool _isShowError;

    private float _midSpliterPos = 200f;
    
    private Vector2 _filterListScrollViewPosition = new Vector2(0, 0);
    
    private Vector2 _logListScrollViewPosition = new Vector2(0, 0);

    private BaseSplitView _midSplitView;
}