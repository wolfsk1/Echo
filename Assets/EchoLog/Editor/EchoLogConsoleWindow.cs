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
        EchoLogConsoleWindow window = (EchoLogConsoleWindow)GetWindow(typeof (EchoLogConsoleWindow),false,"WLog Console");
        window.Show();

    }
    
    void OnGUI ()
    {
//        EditorGUILayout.BeginScrollView(new Vector2(0, 0), true, false);
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.BeginVertical(new GUILayoutOption[]{GUILayout.Width(200)});
        GUILayout.Label("Fliter List");
        GUILayout.BeginScrollView(new Vector2(0, 0),GUILayout.MaxWidth(200),GUILayout.MaxHeight(100));
        if (GUILayout.Button("Add Fliter"))
        {
            
        }
        if (GUILayout.Button("Add Fliter"))
        {
            
        }
        if (GUILayout.Button("Add Fliter"))
        {
            
        }
        if (GUILayout.Button("Add Fliter"))
        {
            
        }
        EditorGUILayout.EndScrollView();
        if (GUILayout.Button("Add Fliter"))
        {
            
        }
        EditorGUILayout.EndVertical();
        EditorGUILayout.BeginVertical();
        EditorGUILayout.BeginHorizontal();
        _isShowError = GUILayout.Toggle(_isShowError, "Error", EditorStyles.toolbarButton);
        _isShowLog = GUILayout.Toggle(_isShowLog, "Log", EditorStyles.toolbarButton);
        _isShowWarning = GUILayout.Toggle(_isShowWarning, "Warning", EditorStyles.toolbarButton);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.EndVertical();
        EditorGUILayout.EndHorizontal();
//        //输入框控件
//        text = EditorGUILayout.TextField("输入文字:",text);
// 
//        if(GUILayout.Button("打开通知",GUILayout.Width(200)))
//        {
//            //打开一个通知栏
//            this.ShowNotification(new GUIContent("This is a Notification"));
//        }
// 
//        if(GUILayout.Button("关闭通知",GUILayout.Width(200)))
//        {
//            //关闭通知栏
//            this.RemoveNotification();
//        }
// 
//        //文本框显示鼠标在窗口的位置
//        EditorGUILayout.LabelField ("鼠标在窗口的位置", Event.current.mousePosition.ToString ());
// 
//        //选择贴图
//        texture =  EditorGUILayout.ObjectField("添加贴图",texture,typeof(Texture),true) as Texture;
// 
//        if(GUILayout.Button("关闭窗口",GUILayout.Width(200)))
//        {
//            //关闭窗口
//            this.Close();
//        }
 
    }

    private void _handleTabSwitch()
    {
        if (_filterSelected != _lastSelectedFilter)
        {
            // do sth
            _lastSelectedFilter = _filterSelected;
        }
        if (_filterSelected == tests.Count - 1)
        {
            tests.Insert(tests.Count - 1, tests.Count.ToString());
            _filterSelected = tests.Count - 2;
        }
    }
    
    public List<string> tests = new List<string>(){"default","+"};

    private int _filterSelected = 0;
    private int _lastSelectedFilter = 0;

    private bool _isShowWarning;
    private bool _isShowLog;
    private bool _isShowError;
}
