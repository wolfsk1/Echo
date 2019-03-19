using System.IO;
using Boo.Lang;
using com.tdb.echo;
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
        window.Show();
    }

    void OnGUI()
    {
        var windowsHeight = position.height;
        var windowsWidth = position.width;
        // 整体布局
        EditorGUILayout.BeginHorizontal();

        _DrawLeftGroupView(windowsHeight);

        _DrawRightGroupView(windowsHeight, windowsWidth - _leftGroupWidth);

        
        EditorGUILayout.EndHorizontal();
    }

    private void _DrawLeftGroupView(float windowsHeight)
    {
        // left
        EditorGUILayout.BeginVertical(GUILayout.Width(_leftGroupWidth));
        
        // Header
        EditorGUILayout.BeginHorizontal(GUILayout.Height(_headerHeight));
        
        GUILayout.Label("Fliter List:");
        
        if (GUILayout.Button("Add Fliter"))
        {
        }

        EditorGUILayout.EndHorizontal();

        // scroll view
        float scrollViewHeight = windowsHeight - _headerHeight;
        _filterListScrollViewPosition = GUILayout.BeginScrollView(_filterListScrollViewPosition,
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

    private void _DrawRightGroupView(float windowsHeight, float groupWidth)
    {
        // right
        EditorGUILayout.BeginVertical();
        
        // header
        EditorGUILayout.BeginHorizontal(GUILayout.Height(_headerHeight));
        
        GUILayout.Space(groupWidth - _rightGroupHeaderButtonWidth * 4 - _separatorLength);
        if (GUILayout.Button("Clear", EditorStyles.toolbarButton))
        {
            
        }
        GUILayout.Space(_separatorLength);
        _isShowError = GUILayout.Toggle(_isShowError, "Error", EditorStyles.toolbarButton, GUILayout.Width(_rightGroupHeaderButtonWidth));
        _isShowLog = GUILayout.Toggle(_isShowLog, "Log", EditorStyles.toolbarButton, GUILayout.Width(_rightGroupHeaderButtonWidth));
        _isShowWarning = GUILayout.Toggle(_isShowWarning, "Warning", EditorStyles.toolbarButton, GUILayout.Width(_rightGroupHeaderButtonWidth));

        // header end
        EditorGUILayout.EndHorizontal();
        
        // scroll view
        float scrollViewHeight = windowsHeight - _headerHeight;
        _logListScrollViewPosition = GUILayout.BeginScrollView(_logListScrollViewPosition,
            GUILayout.Height(scrollViewHeight));

        // filter List content
        if (GUILayout.Button("Add Fliter"))
        {
        }
        // scroll view end
        EditorGUILayout.EndScrollView();
        
        // right end
        EditorGUILayout.EndVertical();
    }

    private readonly float _headerHeight = 30f;

    private readonly float _separatorLength = 5f;
    // left group param
    private readonly float _leftGroupWidth = 200f;
    

    // right group param
    private readonly float _rightGroupHeaderButtonWidth = 80f;
    
    
    // Log Level Button
    private bool _isShowWarning;
    private bool _isShowLog;
    private bool _isShowError;

    private Vector2 _filterListScrollViewPosition = new Vector2(0, 0);
    
    private Vector2 _logListScrollViewPosition = new Vector2(0, 0);
}