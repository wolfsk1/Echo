using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

namespace EchoLog.Editor
{
    public class EditorHorizontalSplitView : BaseSplitView
    {
        
        
        public override void Split(float totalWidth, float totalHeight)
        {
            if (!_isSplitRectInit)
            {
                _splitRect = new Rect(totalWidth*.5f,0f,4f,totalHeight);
                _newSplitRect = _splitRect;
                _isSplitRectInit = true;
                _InvokeResize(_splitRect.x);
            }
            
            EditorGUI.DrawRect(_splitRect, Color.white);
            
            EditorGUIUtility.AddCursorRect(_splitRect ,MouseCursor.ResizeHorizontal);
            
            if( Event.current.type == EventType.MouseDown && _splitRect.Contains(Event.current.mousePosition)){
                _isResize = true;
            }
            
            if (_isResize)
            {
                float newPos = Event.current.mousePosition.x;
                newPos = newPos > totalWidth ? totalWidth : newPos;
                newPos = newPos < 0 ? 0 : newPos;
                _newSplitRect.x = newPos;
                EditorGUI.DrawRect(_newSplitRect, Color.white);
                _rootWindow.Repaint();
                
            }

            if (Event.current.type == EventType.MouseUp)
            {
                _isResize = false;
                _splitRect = _newSplitRect;
                _InvokeResize(_splitRect.x);
            }
        }

        public override void Init(EditorWindow rootWindow, UnityAction<float> onSplitMove)
        {
            _onSplitMove = onSplitMove;
            _rootWindow = rootWindow;
        }

        public override void UnRegisterSplitMoveHanlder()
        {
            _onSplitMove = null;
        }
    }
}