using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Laser : MonoBehaviour
{
	public void Hit ()
	{
		Destroy (gameObject);
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		Laser laser = col.gameObject.GetComponent<Laser> ();

		if (laser) {
			laser.Hit ();
			Destroy (gameObject);
		}
	}
}


