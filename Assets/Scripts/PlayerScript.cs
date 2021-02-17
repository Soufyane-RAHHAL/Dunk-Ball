using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour {
	public static PlayerScript instance;
	private float speed = 3.7f;
	private int Direction = 1;
	private bool canJump;
	private bool TouchTheplatformForThefirstTime=true;
	public bool CanMove;
	private int nNet=0;

	[SerializeField]
	private Rigidbody2D myRigidBody;
	// Use this for initialization
	void Awake(){
		if (instance == null) {
			instance = this;
		}

	}
	void Start () {
		CanMove = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (CanMove) {
			
		}
	}
	void OnCollisionEnter2D(Collision2D target){
		if (target.gameObject.tag == "Border") {
			Direction = -Direction;
		}
		if (target.gameObject.tag == "Platform") {
			Debug.Log ("HHH");
			GamePlayController.instance.GameOver ();	
//			canJump = true;
//
//			CameraMove.instance.lerpY = target.gameObject.transform.position.y+3;
//			CameraMove.instance.lerpCamera = true;
			//GamePlayController.instance.setnumOfJumping (1);
		} if(target.gameObject.tag == "Enimes"){
			CanMove = false;
			canJump = false;
			gameObject.GetComponent<Rigidbody2D> ().isKinematic = true;
			StartCoroutine (WaitForRealTime());
		}
	}
	IEnumerator WaitForRealTime(){
		yield return new WaitForSeconds (1.2f);
		SceneManager.LoadScene ("MainMenu");
	}
	void OnTriggerEnter2D(Collider2D target){
		
		if (target.gameObject.tag == "NetUp") {
			nNet = 1;
		}
		if (target.gameObject.tag == "Net"&&nNet!=0) {
			target.transform.parent.gameObject.SetActive (false);
			GameManagerScript.instance.CreateNewBaksetAndLerp (-5.2f);
			nNet = 0;
			TimerScript.instance.RestartTheTime ();
			GamePlayController.instance.setScore ();
			//	GamePlayController.instance.addScore ();
		}
	}
	public void setCanJump(bool canJump){
		this.canJump = canJump;
		myRigidBody.simulated = true;
	}
	public bool getCanJump(){
		return canJump;
	}
	public void Jump(){
		if (canJump) {
			Direction = -Direction;
			myRigidBody.velocity = new Vector2 (Direction * 1.7f, 4.7f);

		}
	}





}












