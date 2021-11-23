using UnityEngine;
using System;
using System.Collections;

namespace Utils
{
	public class Color32Util
	{
		public static Color32 FromRGBAUint32( UInt32 color)
		{
			return new Color32( GetR( color),
								GetG( color),
								GetB( color),
								GetA( color));
		}

		public static byte GetR( UInt32 color)
		{
			return (byte) ((color >> 24) & 0xff);
		}

		public static byte GetG( UInt32 color)
		{
			return (byte) ((color >> 16) & 0xff);
		}

		public static byte GetB( UInt32 color)
		{
			return (byte) ((color >> 8) & 0xff);
		}

		public static byte GetA( UInt32 color)
		{
			return (byte) (color & 0xff);
		}
	}
}
