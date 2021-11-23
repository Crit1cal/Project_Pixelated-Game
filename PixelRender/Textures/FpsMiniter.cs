using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FpsMiniter : MonoBehaviour
{
	public int avgFrameRate;
	public Text fpsText;
	void Update()
	{
		float current = 0;
		current = Time.frameCount / Time.time;
		avgFrameRate = (int)current;
		fpsText.text = avgFrameRate.ToString() + " FPS";

	}
}
