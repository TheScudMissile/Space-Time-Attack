using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBig : MonoBehaviour
{
	
	public Sprite[] asteroidHits;
	public int maxHits;
	public GameObject debris;
	public AudioClip collision;
	public AudioClip destroyed;


	private float rotSpeed = 10f;
	private int hitsTaken = 0;

	// Update is called once per frame
	void Update ()
	{
		this.transform.Rotate (Vector3.forward * Time.deltaTime * rotSpeed);
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		Laser laser = col.gameObject.GetComponent<Laser> ();

		if (laser) {
			laser.Hit ();
			AudioSource.PlayClipAtPoint (collision, this.transform.position);
			hitsTaken++;

			if (maxHits <= hitsTaken) {
				Destroy (gameObject);
				AudioSource.PlayClipAtPoint (destroyed, this.transform.position);
				Instantiate (debris, this.transform.position, Quaternion.identity);
			} else {
				LoadCurrSprite ();
			}
		}
	}

	void LoadCurrSprite ()
	{
		int idx = hitsTaken - 1;
		this.GetComponent<SpriteRenderer> ().sprite = asteroidHits [idx];
		this.transform.localScale = new Vector3 (3.32f, 3.32f, 3.32f);
	}
}
