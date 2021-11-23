using UnityEngine;
using UnityEditor;
using System.Collections;

namespace GUIWrapper
{
	public class GUIDelayedIntField : GUIBase 
	{
		private int _previousValue;
		public int previousValue { get { return _previousValue; } }
		public int value;
		public int minValue;
		public int maxValue;

		private GUIContent _content;
		public GUIContent content { get { return _content; } }

		public GUIDelayedIntField( GUIContent content, int value=0, int minValue=0, int maxValue=0, OnGUIAction action=null)
		{
			this.value = value;
			_previousValue = value;
			this.minValue = minValue;
			this.maxValue = maxValue;

			_content = content;
			if( action != null)
			{
				onGUIAction += action;
			}
		}

		protected override void CustomOnGUI ()
		{
			int newValue = EditorGUILayout.DelayedIntField( _content, value);

			if( newValue != value && newValue >= minValue && newValue <= maxValue)
			{
				_previousValue = value;
				value = newValue;
				CallGUIAction();
			}
		}
	}
}
