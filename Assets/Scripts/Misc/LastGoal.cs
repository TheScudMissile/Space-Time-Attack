using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LastGoal : MonoBehaviour
{
	public Sprite[] states;
	public string finalTime;
	public GameManagement manager;

	private int numAsteroids;

	// Use this for initialization
	void Start ()
	{
		numAsteroids = GameObject.FindGameObjectsWithTag ("Asteroid").Length;
	}
	
	// Update is called once per frame
	void Update ()
	{
		numAsteroids = GameObject.FindGameObjectsWithTag ("Asteroid").Length;
		LoadCurrSprite ();
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (numAsteroids == 0) {
			StopWatch.playing = false;
			manager.LoadLevel ("Phase_Done");
		}
	}

	void LoadCurrSprite ()
	{
		if (numAsteroids == 0) {
			this.GetComponent<SpriteRenderer> ().sprite = states [1];
		} else {
			this.GetComponent<SpriteRenderer> ().sprite = states [0];
		}
	}
}
