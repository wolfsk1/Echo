using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

namespace EchoLog.Editor
{
    public abstract class BaseSplitView
    {
        public abstract void Split(float totalWidth, float totalHeight);

        public abstract void Init(EditorWindow rootWindow, UnityAction<float> onSplitMove);
        
        public abstract void UnRegisterSplitMoveHanlder();

        protected void _InvokeResize(float value)
        {
            if (_onSplitMove != null)
            {
                _onSplitMove.Invoke(value);
            }
        }

        protected float _totalWidth, _totalHeight;

        protected Rect _splitRect, _newSplitRect;

        protected bool _isSplitRectInit, _isResize;

        protected EditorWindow _rootWindow;

        protected UnityAction<float> _onSplitMove;
    }
}