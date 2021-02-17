using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObstacleSpawner : MonoBehaviour {
	public static ObstacleSpawner instance;
	[SerializeField]
	private GameObject[] obstacles;
	private List<GameObject> obstaclesForSpawing = new List<GameObject> ();
	// Use this for initialization
	private float height;
	private bool isallreadystarted;
	void Awake(){
		if (instance == null)
			instance = this;
		initObstacles ();
	}
	void Start () {
		Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,0));
		height = bounds.y;
		StartCoroutine(SpawnRandomObstacle());

	}
	void initObstacles() {
		int index = 0;
		for (int i = 0; i < obstacles.Length * 3; i++) {
			GameObject obj = Instantiate (obstacles [index], new Vector3(transform.position.x,transform.position.y,
																		-2), Quaternion.identity)as GameObject;
			obstaclesForSpawing.Add (obj);
			obstaclesForSpawing [i].SetActive (false);
			index++;
			if(index==obstacles.Length)
				index=0;
		}
	}
	void Shuffle(){
		for(int i =0;i<obstaclesForSpawing.Count;i++){
			GameObject temp = obstaclesForSpawing [i];
			int random = Random.Range (i, obstaclesForSpawing.Count);
			obstaclesForSpawing [i] = obstaclesForSpawing [random];
			obstaclesForSpawing [random] = temp;

		}
	}
	void Update(){
		
	}
	 
	public	IEnumerator SpawnRandomObstacle(){
		yield return new WaitForSeconds (Random.Range (0f, 4f));

		int index = Random.Range (0,obstaclesForSpawing.Count);
		while (true) {
			if (!obstaclesForSpawing [index].activeInHierarchy) {
				obstaclesForSpawing [index].SetActive (true);
				obstaclesForSpawing [index].transform.position = new Vector3 (transform.position.x+Random.Range(-1,height-2),transform.position.y, -2);
				break;
			} else {
				index = Random.Range (0, obstaclesForSpawing.Count);
			}
		}
		StartCoroutine (SpawnRandomObstacle());
	}

}































