using UnityEngine;
using UnityEditor;
using System.Collections;

namespace GUIWrapper
{
	public class GUILabel : GUIBase 
	{
		private GUIContent _content;
		public GUIContent content { get { return _content; } }

		public GUIStyle style;
		
		public GUILabel( GUIContent content)
		{
			_content = content;
		}
		
		protected override void CustomOnGUI ()
		{
			if( style == null) {
				GUILayout.Label( _content);
			}
			else {
				GUILayout.Label( _content, style);
			}
		}
	}
}
