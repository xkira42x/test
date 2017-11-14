using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2_Hand : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 mousepos=Camera.main.ScreenToWorldPoint (Input.mousePosition);
		this.transform.position = new Vector3 (mousepos.x, mousepos.y, 0);
	}
}
