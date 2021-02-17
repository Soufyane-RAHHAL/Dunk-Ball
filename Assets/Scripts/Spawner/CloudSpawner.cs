using UnityEngine;
using System.Collections;

public class CloudSpawner : MonoBehaviour {
   [SerializeField]
	private GameObject[] Obstacles;
    private float distanceBetweenObstacles ;
    private float minY, maxY;
    private float lastObstaclePositionX;
	public static CloudSpawner instance;

	// Use this for initialization
	void Awake() {
		if (instance == null)
			instance = this;
        SetMinAndMaxX();
		distanceBetweenObstacles =2.7f;
		CreateObstacles();



	}
	void Shuffle(GameObject[] arrayToShuffle)
	{
		for (int i = 0; i < arrayToShuffle.Length; i++)
		{
			GameObject temp = arrayToShuffle[i];
			int random = Random.Range(i,arrayToShuffle.Length);
			arrayToShuffle[i] = arrayToShuffle[random];
			arrayToShuffle[random] = temp;
		}
	}
    void Start()
    {
		
    }
    void SetMinAndMaxX()
    {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,0));
		maxY = bounds.y - 3f;
        minY = -bounds.y + 3f;
    }


	void CreateObstacles()
    {
		Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,0));
		float positionX = -5;
	
		for (int i = 0; i < Obstacles.Length; i++)
        {
			Vector3 temp = Obstacles[i].transform.position;
			temp.y = positionX;
			temp.x = 0;


			lastObstaclePositionX = positionX;
			Obstacles[i].transform.position = temp;
			positionX += distanceBetweenObstacles;
        }
    }

   

        void OnTriggerEnter2D(Collider2D target){

        if (target.tag=="Platform"){
			//Debug.Log (target.transform.position.y+" vs  " +lastObstaclePositionX);
			if (target.transform.position.y == lastObstaclePositionX){
	
				Shuffle (Obstacles);
				Vector3 temp = target.transform.position;
				for (int i = 0; i <Obstacles.Length; i++)
                {
					if (!Obstacles[i].activeInHierarchy) {
						temp.x =0;
						temp.y += distanceBetweenObstacles;
						lastObstaclePositionX = temp.y;
						Obstacles[i].transform.position = temp;
						Obstacles [i].transform.rotation = Quaternion.Euler (0,0,0);
						Obstacles[i].SetActive(true);

                    }
                }
               
            }
		} 
    }

}
