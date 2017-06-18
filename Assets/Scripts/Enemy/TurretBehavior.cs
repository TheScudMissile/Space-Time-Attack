using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBehavior : MonoBehaviour
{
	public GameObject laserPrefab;
	public AudioClip turretSound;
	public GameManagement manager;

	private float rotSpeed;
	private float laserSpeed;

	// Use this for initialization
	void Start ()
	{
		rotSpeed = 50f;
		laserSpeed = 250f;
		manager = FindObjectOfType<GameManagement> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		this.transform.Rotate (Vector3.forward * Time.deltaTime * rotSpeed);
		HandleProjectiles ();
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		Destroy (col.gameObject);
		manager.Restart ();
	}

	void HandleProjectiles ()
	{
		Vector3 laserPos = this.transform.GetChild (0).position;

		float decisionBound = Random.Range (0f, 1f);

		if (decisionBound > 0.998f) {
			GameObject laser = Instantiate (laserPrefab, 
				                   laserPos, transform.rotation) as GameObject;

			AudioSource.PlayClipAtPoint (turretSound, this.transform.position);

			laser.GetComponent<Rigidbody2D> ().velocity = 
								this.transform.up * Time.deltaTime * laserSpeed;	
		}
	}
}
