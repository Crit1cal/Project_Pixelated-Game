using UnityEngine;
using UnityEditor;
using System.Collections;

namespace GUIWrapper
{
	public class GUIPopup : GUIBase 
	{
		public int selectedIndex;

		private GUIContent[] _displayedOptions;
		public GUIContent[] displayedOptions {
			get { return _displayedOptions; }
			set {
				bool valid = value != null && value.Length > 0;

				if( valid) { _displayedOptions = value; }
				else { _displayedOptions = new GUIContent[1] {new GUIContent( "None")}; }

				selectedIndex = 0;
			}
		}

		private GUIContent _content;
		public GUIContent content { get { return _content; } }

		public GUIPopup( GUIContent content, GUIContent[] displayedOptions, int selectedIndex=0, OnGUIAction action=null)
		{
			this.displayedOptions = displayedOptions;
			this.selectedIndex = selectedIndex;
			_content = content;

			if( action != null)
			{
				onGUIAction += action;
			}
		}

		protected override void CustomOnGUI ()
		{
			int newIndex = EditorGUILayout.Popup( _content, selectedIndex, displayedOptions);
			if( newIndex != selectedIndex)
			{
				selectedIndex = newIndex;
				CallGUIAction();
			}
		}
	}
}
