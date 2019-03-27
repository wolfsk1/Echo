using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEngine.Events;

public class EditorGUISplitView
{

	public enum Direction {
		Horizontal,
		Vertical
	}




	public EditorGUISplitView(Direction splitDirection, UnityAction<float> onSplitViewMove) {
		_splitDirection = splitDirection;
		_currentPos = 0;
		_onResize = onSplitViewMove;
	}

	public void BeginSplitView(float width, float height)
	{

		_availableRect.width = width;
		_availableRect.height = height;
		if(_splitDirection == Direction.Horizontal)
			EditorGUILayout.BeginHorizontal (GUILayout.Width(width));
		else 
			EditorGUILayout.BeginVertical (GUILayout.Height(height));

		
		if(_splitDirection == Direction.Horizontal)
			_scrollPosition = GUILayout.BeginScrollView(_scrollPosition, GUILayout.Width(_availableRect.width * _splitNormalizedPosition));
		else
			_scrollPosition = GUILayout.BeginScrollView(_scrollPosition, GUILayout.Height(_availableRect.height * _splitNormalizedPosition));
	}

	public void Split() {
		GUILayout.EndScrollView();
		ResizeSplitFirstView ();
	}

	public void Split(float totalWidth, float totalHeight)
	{
		if (!_isSplitRectInit)
		{
			if (_splitDirection == Direction.Horizontal)
			{
				_splitRect = new Rect(totalWidth*.5f,0f,4f,totalHeight);
			}
			else
			{
				_splitRect = new Rect(0f, totalHeight * .5f, totalWidth, 4f);
			}
			_isSplitRectInit = true;
			
		}
		if(_splitDirection == Direction.Horizontal)
			EditorGUIUtility.AddCursorRect(_resizeHandlerRect,MouseCursor.ResizeHorizontal);
		else
			EditorGUIUtility.AddCursorRect(_resizeHandlerRect,MouseCursor.ResizeVertical);
		if (_resize)
		{
			
		}
		else
		{
			_totalHeight = totalHeight;
			_totalWidth = totalWidth;
			
		}
		
		
	}

	private void _InvokeResize()
	{
		//if(_splitDirection)
	}
	
	public void EndSplitView() {

		if(_splitDirection == Direction.Horizontal)
			EditorGUILayout.EndHorizontal ();
		else 
			EditorGUILayout.EndVertical ();
	}

	private void ResizeSplitFirstView()
	{
		if (!_isSplitRectInit)
		{
			if(_splitDirection == Direction.Horizontal)
				_resizeHandlerRect = new Rect (_availableRect.width * _splitNormalizedPosition, _availableRect.y, 2f, _availableRect.height);
			else
				_resizeHandlerRect = new Rect (_availableRect.x,_availableRect.height * _splitNormalizedPosition, _availableRect.width, 2f);
			_isSplitRectInit = true;
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
	private float _totalWidth, _totalHeight, _currentPos;
	private float _splitNormalizedPosition;
	private Rect _splitRect;
	private UnityAction<float> _onResize;
	
	private bool _resize;
	private Vector2 _scrollPosition;
	private Rect _availableRect;
	private Rect _resizeHandlerRect;
	private bool _isSplitRectInit = false;
}

