using UnityEngine;
using System;
using System.Collections;

namespace Extensions
{
	public static class Color32Extensions
	{
		public static UInt32 ToRGBAUInt32( this Color32 color)
		{
			return ((UInt32)color.r << 24) | 
				   ((UInt32)color.g << 16) | 
				   ((UInt32)color.b << 8) | 
				   (UInt32)color.a;
		}
	}
}