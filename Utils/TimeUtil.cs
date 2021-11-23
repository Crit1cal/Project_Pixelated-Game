using UnityEngine;
using System.Collections;

namespace Utils
{
	public class TimeUtil
	{
		/// <summary>
		/// </summary>
		/// <param name="normalizedTime"></param>
		/// <param name="loopCount"></param>
		/// <param name="pingPong"></param>
		public static float Loop( float normalizedTime, int loopCount, bool pingPong=false)
		{
			float loopedTime = normalizedTime * (float)(loopCount + 1);
			float subTime = loopedTime - Mathf.Floor( loopedTime);

			if( pingPong && ((int)loopedTime % 2) == 1) {
				subTime = 1.0f - subTime;
			}

			return subTime;
		}
	}
}
