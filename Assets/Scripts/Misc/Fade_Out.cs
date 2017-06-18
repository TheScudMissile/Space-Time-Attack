using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade_Out : MonoBehaviour
{
	private float fadeTime;
	private Image panel;
	private Color currColor;

	// Use this for initialization
	void Start ()
	{
		fadeTime = 2f;
		currColor = Color.black;
		currColor.a = 0;
		panel = GetComponent<Image> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Time.timeSinceLevelLoad < fadeTime) {
			float AlphaChangePerFrame = Time.deltaTime / fadeTime;
			currColor.a += AlphaChangePerFrame;
			panel.color = currColor;

		} else {
			Destroy (panel);
		}
	}
}
