using Boo.Lang;
using com.tdb.echo;
using UnityEditor;
using UnityEngine;

public class EchoLogConsoleWindow : EditorWindow
{
    [MenuItem("WLog/LogConsole")]
    public static void Init()
    {
        EchoManager.Instance.GetLogHandler<EchoUILogHandler>();
        //创建窗口
        Rect  wr = new Rect (0,0,500,500);
        EchoLogConsoleWindow window = (EchoLogConsoleWindow)EditorWindow.GetWindowWithRect (typeof (EchoLogConsoleWindow),wr,true,"WLog Console");	
        window.Show();
        
    }
    
    void OnGUI ()
    {
//        EditorGUILayout.BeginScrollView(new Vector2(0, 0), true, false);
        EditorGUILayout.BeginVertical();
        _filterSelected = GUILayout.Toolbar(_filterSelected, tests.ToArray());
        
        EditorGUILayout.EndVertical();
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
}
