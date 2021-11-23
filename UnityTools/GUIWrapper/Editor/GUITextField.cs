using UnityEngine;
using UnityEditor;
using System.Collections;

namespace GUIWrapper
{
	public class GUITextField : GUIBase 
	{
		public string value;

		private GUIContent _content;
		public GUIContent content { get { return _content; } }
		
		public GUITextField( GUIContent content, string value="", OnGUIAction action=null)
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
			string newValue = EditorGUILayout.TextField( _content, value);
			if( newValue != value)
			{
				value = newValue;
				CallGUIAction();
			}
		}
	}
}
