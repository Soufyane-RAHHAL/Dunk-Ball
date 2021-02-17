using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {
	public static CameraMove instance;
	private  float offsetY;
	private float height , width;
    
	public bool lerpCamera;
	private float lerpTime=0.1f;
	public float lerpY;
	// Use this for initialization
	void Awake(){
		if (instance == null)
			instance = this;
	}
	void Start () {
		height = Camera.main.orthographicSize * 2f;
		width = height * Screen.width / Screen.height;
		offsetY = width/4;

	}

	// Update is called once per frame
	void Update () {
		if (PlayerScript.instance != null) {

				if (lerpCamera) {
			LerpTheCamera ();
	 	}
  }
}
	void MoveThecamera(){
		Vector3 temp = transform.position;
		//temp.x =PlayerScript.instance.GetpostionX()+offsetY;
		transform.position = temp;
	}
    	void LerpTheCamera(){
		float y = Camera.main.transform.position.y;
		y = Mathf.Lerp (y,lerpY,lerpTime);
			
		Camera.main.transform.position = new Vector3 (Camera.main.transform.position.x,y,Camera.main.transform.position.z);
		if (Camera.main.transform.position.y >= (lerpY ))
			lerpCamera = false;
	}
}
