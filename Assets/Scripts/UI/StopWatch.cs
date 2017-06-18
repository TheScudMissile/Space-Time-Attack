using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StopWatch : MonoBehaviour
{
	public static float time = 0;
	public static bool playing = true;

	private float min;
	private float sec;
	private float decim;

	private Text text;
	private string finalTime;

	// Use this for initialization
	void Start ()
	{
		text = GetComponent<Text> ();

		if (text) {
			text.text = time.ToString ();
		}
	}

	void Update ()
	{
		if (text && playing) {
			time += Time.deltaTime;

			
			string formatted = Convert (time);
			text.text = formatted;
		}
	}

	public static void Reset ()
	{
		time = 0;
	}

	public static string Convert (float time)
	{
		TimeSpan span = TimeSpan.FromSeconds (time);
		string converted = string.Format ("{0:D2}:{1:D2}.{2}", 
			span.Minutes, span.Seconds, span.Milliseconds);
		
		return converted;
	}
}
