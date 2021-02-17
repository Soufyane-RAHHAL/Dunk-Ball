using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ObstacleOffScreen : MonoBehaviour {
	
	void OnTriggerEnter2D(Collider2D target){
	//	if (target.tag == "Collector") {
		target.gameObject.GetComponent<BoxCollider2D>().isTrigger=true;	
			target.gameObject.SetActive (false);

	//	}
	}
}
