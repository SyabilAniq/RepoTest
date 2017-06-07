using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairController : MonoBehaviour {

	public Vector3 rawMousepos;
	public Vector3 worldMousepos;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		rawMousepos = Input.mousePosition;

		worldMousepos = Camera.main.ScreenToWorldPoint (rawMousepos);
		worldMousepos.z = 0f;
		this.transform.position = worldMousepos;
		Cursor.visible = false;
	}
}
