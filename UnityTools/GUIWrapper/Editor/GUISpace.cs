﻿using UnityEngine;
using UnityEditor;
using System.Collections;

namespace GUIWrapper
{
	public class GUISpace : GUIBase 
	{
		bool isFlexible;

		public GUISpace( bool isFlexible = false)
		{
			this.isFlexible = isFlexible;
		}

		protected override void CustomOnGUI()
		{
			if( isFlexible)
			{
				GUILayout.FlexibleSpace();
			}
			else
			{
				GUILayout.Space( 20.0f);
			}
		}
	}
}
