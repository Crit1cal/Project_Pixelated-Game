using UnityEngine;
using UnityEditor;
using System.Collections;

namespace GUIWrapper
{
	public class GUIEnumPopup : GUIBase 
	{
		public System.Enum value;

		private GUIContent _content;
		public GUIContent content { get { return _content; } }

		public GUIEnumPopup( GUIContent content, System.Enum value, OnGUIAction action=null)
		{
			this.value = value;

			_content = content;
			if( action != null)
			{
				onGUIAction += action;
			}
		}

		protected override void CustomOnGUI ()
		{
			System.Enum newValue = EditorGUILayout.EnumPopup( _content, value);
			if( newValue != value)
			{
				value = newValue;
				CallGUIAction();
			}
		}
	}
}
