using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
	public Sprite[] states;
	public Ship ship;

	private Vector3 shipPos;

	private float minGoalX;
	private float maxGoalX;
	private float minGoalY;
	private float maxGoalY;

	private int numAsteroids;

	// Use this for initialization
	void Start ()
	{
		ship = FindObjectOfType<Ship> ();
		shipPos = ship.transform.position;

		minGoalX = this.transform.position.x - 0.9f;
		maxGoalX = this.transform.position.x + 0.9f;
		minGoalY = this.transform.position.y - 0.9f;
		maxGoalY = this.transform.position.y + 0.9f;

		numAsteroids = GameObject.FindGameObjectsWithTag ("Asteroid").Length;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (ship) {
			shipPos = ship.transform.position;
		}
		numAsteroids = GameObject.FindGameObjectsWithTag ("Asteroid").Length;
		LoadCurrSprite ();

		if (numAsteroids == 0 && (minGoalX < shipPos.x && shipPos.x < maxGoalX) && (minGoalY < shipPos.y && shipPos.y < maxGoalY)) {
			GameManagement.LoadNext ();
		}
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (numAsteroids == 0) {
			GameManagement.LoadNext ();
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
