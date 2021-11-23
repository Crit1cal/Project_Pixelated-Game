using UnityEngine;
using UnityEditor;
using System.Collections;

namespace GUIWrapper
{
	public class GUIObjectField<T> : GUIBase where T : UnityEngine.Object
	{
		public T value;
		public bool allowsSceneObjects;

		private GUIContent _content;
		public GUIContent content { get { return _content; } }

		public GUIObjectField( GUIContent content, bool allowsSceneObjects=true, OnGUIAction action=null, OnGUIPreAction preAction=null)
		{
			_content = content;
			this.allowsSceneObjects = allowsSceneObjects;
			if( preAction != null)
			{
				onGUIPreAction += preAction;
			}

			if( action != null)
			{
				onGUIAction += action;
			}
		}

		protected override void CustomOnGUI ()
		{
			T newValue = EditorGUILayout.ObjectField( _content, value, typeof( T), allowsSceneObjects) as T;
			if( newValue != value)
			{
				CallGUIPreAction();
				value = newValue;
				CallGUIAction();
			}
		}
	}
}
