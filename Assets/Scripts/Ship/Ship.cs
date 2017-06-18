using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
	public ParticleSystem thrust;
	public GameObject laserPrefab;
	public AudioClip laserSound;
	
	public GameObject debris;
	public AudioClip destroyed;

	private float shipSpeed;
	private float rotateSpeed;
	private float laserSpeed;

	private bool hasStarted;
	private Vector3 direction;
	private AudioSource source;

	private bool counterPressed;
	private bool clockPressed;
	private bool thrustPressed;

	// Use this for initialization
	void Start ()
	{
		shipSpeed = 1f;
		rotateSpeed = 200f;
		laserSpeed = 2000f;	

		hasStarted = false;
		source = this.GetComponent<AudioSource> ();
		counterPressed = false;
		clockPressed = false;
		thrustPressed = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		Movement ();
		HandleProjectiles ();
	}

	void Movement ()
	{
		if (Input.GetKey (KeyCode.UpArrow) || thrustPressed) {
			Thrust ();
		} else {
			thrust.Stop ();
			source.Stop ();
		}
		if (hasStarted && !(Input.GetKey (KeyCode.UpArrow))) {
			this.transform.position += direction * Time.deltaTime * shipSpeed;
		}

		if (Input.GetKey (KeyCode.LeftArrow) || counterPressed) {
			RotateCounter ();
		}

		if (Input.GetKey (KeyCode.RightArrow) || clockPressed) {
			RotateClock ();
		}
	}

	void HandleProjectiles ()
	{
		if (Input.GetKeyDown (KeyCode.Space)) {
			Fire ();
		}	
	}

	public void Fire ()
	{
		Vector3 laserPos = this.transform.GetChild (1).position;
		GameObject laser = Instantiate (laserPrefab, 
			                   laserPos, transform.rotation) as GameObject;
		AudioSource.PlayClipAtPoint (laserSound, this.transform.position);

		laser.GetComponent<Rigidbody2D> ().velocity = 
										this.transform.up * Time.deltaTime * laserSpeed;
	}

	public void RotateCounter ()
	{
		this.transform.Rotate (Vector3.forward * Time.deltaTime * rotateSpeed);
	}

	public void RotateClock ()
	{
		this.transform.Rotate (Vector3.back * Time.deltaTime * rotateSpeed);
	}

	public void Thrust ()
	{
		thrust.Play ();
			
		if (!source.isPlaying && hasStarted) {
			source.Play ();
		}

		Rigidbody2D rb = this.GetComponent<Rigidbody2D> ();

		rb.AddForce (this.transform.up * shipSpeed * 2);

		hasStarted = true;
		direction = transform.up;
	}

	public void OnPointerDownRotateCounter ()
	{
		counterPressed = true; 
	}

	public void OnPointerUpRotateCounter ()
	{
		counterPressed = false;
	}

	public void OnPointerDownThrust ()
	{
		thrustPressed = true;
	}

	public void OnPointerUpThrust ()
	{
		thrustPressed = false;
	}

	public void OnPointerDownRotateClock ()
	{
		clockPressed = true; 
	}

	public void OnPointerUpRotateClock ()
	{
		clockPressed = false;
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		Enemy_Laser eLaser = col.gameObject.GetComponent<Enemy_Laser> ();
		TurretBehavior turret = col.gameObject.GetComponent<TurretBehavior> ();
		AsteroidBig big = col.gameObject.GetComponent<AsteroidBig> ();
		AsteroidMed med = col.gameObject.GetComponent<AsteroidMed> ();
		AsteroidSmall small = col.gameObject.GetComponent<AsteroidSmall> ();

		if (eLaser) {
			eLaser.Hit ();
			Destroy (gameObject);
			AudioSource.PlayClipAtPoint (destroyed, this.transform.position);
			Instantiate (debris, this.transform.position, Quaternion.identity);
		}

		if (big || med || small || turret || col.tag == "Wall") {
			Destroy (gameObject);
			AudioSource.PlayClipAtPoint (destroyed, this.transform.position);
			Instantiate (debris, this.transform.position, Quaternion.identity);
		}
	}
}
