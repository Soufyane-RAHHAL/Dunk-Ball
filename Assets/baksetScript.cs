using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baksetScript : MonoBehaviour {
	private float speed = 0.03f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 temp = this.transform.position;
		temp.x += speed;
		this.transform.position = temp;

	}
	void OnTriggerEnter2D(Collider2D target){
		if (target.gameObject.tag == "Border") {
			speed = -speed;
		}
	}

}
