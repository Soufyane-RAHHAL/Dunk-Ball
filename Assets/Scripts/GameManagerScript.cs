using UnityEngine;
using System.Collections;

public class GameManagerScript : MonoBehaviour {

	public static GameManagerScript instance;
	[SerializeField] 
	private GameObject player;
	[SerializeField]
	private GameObject[] Baksets;

	//private float minX=-2.5f,maxX=2.5f,minY=-4.7f,maxY=-3.2f;

	private bool lerpCamera;
	private float lerpTime=1.5f;
	private float lerpY;
	private float cameraY ;
	private float Distance= 4.8f;
	void Awake(){
		MakeInstance();
		CreateInitialBaksets ();
	}
	void Update(){
		if (lerpCamera) {
			LerpTheCamera ();
		}
	}


	void MakeInstance(){
		if (instance == null)
			instance = this;
	}
	void CreateInitialBaksets(){
		//Vector3 temp = new Vector3 (Random.Range(minX,minX+1.2f),Random.Range(minY,maxY),0);
		Vector3 temp = new Vector3 (0,0,0);
		Instantiate (Baksets[2],temp,Quaternion.identity);
		cameraY = Baksets[0].transform.position.y - Distance;
		//temp.y += 4f;
		//Instantiate (player,temp,Quaternion.identity);
	
//		temp = new Vector3 (Random.Range(maxX,maxX-1.2f),Random.Range(minY,maxY),0);
//		Instantiate (Bakset,temp,Quaternion.identity);
	
	}
	void LerpTheCamera(){
		float y = Camera.main.transform.position.y;
		y = Mathf.Lerp (y,lerpY,lerpTime*Time.deltaTime);

		Camera.main.transform.position = new Vector3 (Camera.main.transform.position.x,y,Camera.main.transform.position.z);
		if (Camera.main.transform.position.y <= (lerpY + 0.07f))
			lerpCamera = false;
	}



	public void CreateNewBaksetAndLerp(float lerpPosition){
		CreateNewBakset ();

		lerpY = lerpPosition + Camera.main.transform.position.y;
		lerpCamera = true;
	}

	void CreateNewBakset(){
		
	//	float newMaxY = (maxY * 2) + cameraY;
		//Instantiate (Bakset, new Vector3 (Random.Range (maxY, maxY - 1.2f),Random.Range (newMaxY, newMaxY - 1.2f), 0), Quaternion.identity);
		int index = Random.Range(0,4);
		if (index == 0) {
			Instantiate (Baksets [0], new Vector3 (Random.Range (-2.7f, 2.7f), cameraY, 0), Quaternion.Euler (0, 0, 20));
		}else if (index == 1) {
			Instantiate (Baksets [0], new Vector3 (Random.Range (-2.7f, 2.7f), cameraY, 0), Quaternion.Euler (0, 0, -20));
		}else if (index == 2) {
			Instantiate (Baksets [2], new Vector3 (Random.Range (-2.7f, 2.7f), cameraY, 0), Quaternion.Euler (0, 0, 0));
		}else  {
			Instantiate (Baksets [0], new Vector3 (Random.Range (-2.7f, 2.7f), cameraY, 0), Quaternion.Euler (0, 0, 0));
		}
		cameraY -= Distance;
	}


}






















