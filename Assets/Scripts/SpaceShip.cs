using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour 
{

	public float speed = 2f;
	public Vector3 velocity;
	public GameObject bullet; // Basic Projectile
	public CrosshairController crossHair;
	public Vector3 direction;
	public float rotSpeed = 15f;

	void Awake () 
	{
		Debug.Log ("I have awaken");
	}

	void OnEnable () 
	{
		Debug.Log ("ENABLING systems");
	}

	// Use this for initialization
	void Start () 
	{
		Debug.Log ("Starts here...");
	}
	
	// Update is called once per frame
	void Update () 
	{
		Orientation ();
		Movement ();
		Fire ();
	}

	void Orientation ()
	{
		/*Vector3 direction = crossHair.worldMousepos - this.transform.position;
		direction.z = 0f;
		transform.LookAt (transform.forward, direction);*/
		direction = crossHair.transform.position - this.transform.position;
		direction.Normalize();
		float angle = Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg;

		this.transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.Euler(0,0,angle-90) , Time.deltaTime * rotSpeed);
	}

	void Movement ()
	{
		velocity.x = Input.GetAxis ("Horizontal");
		velocity.y = Input.GetAxis ("Vertical");

		this.transform.Translate (velocity * Time.deltaTime * speed, Space.World);
	}

	void Fire ()
	{
		if (Input.GetButtonDown ("Fire1")) 
		{
			Instantiate (bullet, this.transform.position, this.transform.rotation);
		}
	}
}