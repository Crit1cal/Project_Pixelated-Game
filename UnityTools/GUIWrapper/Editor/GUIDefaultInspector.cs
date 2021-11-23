﻿using UnityEngine;
using UnityEditor;
using System.Collections;

namespace GUIWrapper
{
	public class GUIDefaultInspector : GUIBase 
	{
		Object target;

		public GUIDefaultInspector( Object target)
		{
			this.target = target;
		}
		
		protected override void CustomOnGUI ()
		{
			UnityEditor.Editor editor = null;
			UnityEditor.Editor.CreateCachedEditor( target, null, ref editor);
			editor.DrawDefaultInspector();
		}
	}
}
