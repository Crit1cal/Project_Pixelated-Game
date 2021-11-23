using UnityEngine;
using UnityEditor;
using System.Collections;

namespace GUIWrapper
{
	public class GUIScrollView : GUIBaseContainer 
	{
		public GUILayoutOption[] layoutOptions;

		private Vector2 _scrollPosition;

		public GUIScrollView( params GUILayoutOption[] options)
		{
			layoutOptions = options;
		}

		protected override void BeginContainerOnGUI()
		{
			_scrollPosition = EditorGUILayout.BeginScrollView( _scrollPosition, layoutOptions);
		}

		protected override void EndContainerOnGUI()
		{
			EditorGUILayout.EndScrollView();
		}
	}
}
