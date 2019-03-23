using UnityEngine;
using System.Collections;
using UnityEditor;

public class EditorGUISplitView
{

	public enum Direction {
		Horizontal,
		Vertical
	}




	public EditorGUISplitView(Direction splitDirection) {
		_splitNormalizedPosition = 0.5f;
		_splitDirection = splitDirection;

	}

	public void BeginSplitView() {
		Rect tempRect;

		if(_splitDirection == Direction.Horizontal)
			tempRect = EditorGUILayout.BeginHorizontal (GUILayout.ExpandWidth(true));
		else 
			tempRect = EditorGUILayout.BeginVertical (GUILayout.ExpandHeight(true));
		
		if (tempRect.width > 0.0f) {
			_availableRect = tempRect;
		}
		if(_splitDirection == Direction.Horizontal)
			_scrollPosition = GUILayout.BeginScrollView(_scrollPosition, GUILayout.Width(_availableRect.width * _splitNormalizedPosition));
		else
			_scrollPosition = GUILayout.BeginScrollView(_scrollPosition, GUILayout.Height(_availableRect.height * _splitNormalizedPosition));
	}

	public void Split() {
		GUILayout.EndScrollView();
		ResizeSplitFirstView ();
	}

	public void EndSplitView() {

		if(_splitDirection == Direction.Horizontal)
			EditorGUILayout.EndHorizontal ();
		else 
			EditorGUILayout.EndVertical ();
	}

	private void ResizeSplitFirstView()
	{
		if (!_isResizeHandlerRectInit)
		{
			if(_splitDirection == Direction.Horizontal)
				_resizeHandlerRect = new Rect (_availableRect.width * _splitNormalizedPosition, _availableRect.y, 2f, _availableRect.height);
			else
				_resizeHandlerRect = new Rect (_availableRect.x,_availableRect.height * _splitNormalizedPosition, _availableRect.width, 2f);
			_isResizeHandlerRectInit = true;
		}
		
		if (_splitDirection == Direction.Horizontal)
			_resizeHandlerRect.x = _availableRect.width * _splitNormalizedPosition;
		else
			_resizeHandlerRect.y = _availableRect.height * _splitNormalizedPosition;

		GUI.DrawTexture(_resizeHandlerRect,EditorGUIUtility.whiteTexture);

		if(_splitDirection == Direction.Horizontal)
			EditorGUIUtility.AddCursorRect(_resizeHandlerRect,MouseCursor.ResizeHorizontal);
		else
			EditorGUIUtility.AddCursorRect(_resizeHandlerRect,MouseCursor.ResizeVertical);

		if( Event.current.type == EventType.MouseDown && _resizeHandlerRect.Contains(Event.current.mousePosition)){
			_resize = true;
		}
		if(_resize){
			if(_splitDirection == Direction.Horizontal)
				_splitNormalizedPosition = Event.current.mousePosition.x / _availableRect.width;
			else
				_splitNormalizedPosition = Event.current.mousePosition.y / _availableRect.height;
			
			
		}
		if(Event.current.type == EventType.MouseUp)
			_resize = false;        
	}
	
	private readonly Direction _splitDirection;
	private float _splitNormalizedPosition;
	private bool _resize;
	private Vector2 _scrollPosition;
	private Rect _availableRect;
	private Rect _resizeHandlerRect;
	private bool _isResizeHandlerRectInit = false;
}

