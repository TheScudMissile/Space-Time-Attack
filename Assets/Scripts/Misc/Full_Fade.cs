using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Full_Fade : MonoBehaviour
{
	private float fadeTime;
	private float fadeInTime;
	private float fadeOutTime;
	private Image panel;
	private Color currColor;

	// Use this for initialization
	void Start ()
	{
		fadeTime = 6f;
		fadeInTime = 3f;
		fadeOutTime = 3f;

		currColor = Color.black;
		panel = GetComponent<Image> ();

	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Time.timeSinceLevelLoad <= fadeTime) {
			if (Time.timeSinceLevelLoad < fadeInTime) {
				float AlphaChangePerFrame = Time.deltaTime / fadeInTime;
				currColor.a -= AlphaChangePerFrame;
				panel.color = currColor;

			} else {
				float AlphaChangePerFrame = Time.deltaTime / fadeOutTime;
				currColor.a += AlphaChangePerFrame;
				panel.color = currColor;
			}
		} else {
			GameManagement.LoadNext ();
		}
	}
}
