using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GamePlayController : MonoBehaviour {
	public static GamePlayController instance;
	private int FirstAction;
	[SerializeField]
	private Text ScoreText,GameOverText;
	private int Score;
	// Use this for initialization
	void Awake(){
		if (instance == null)
			instance = this;
		FirstAction = 0;
	}

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void JumpButton(){
		if (FirstAction == 0) {
			FirstAction = 1;
			PlayerScript.instance.setCanJump (true);
		} else {
			PlayerScript.instance.Jump ();
		}
	}
	public void setScore(){
		Score++;
		ScoreText.text = ""+Score;
	}
	public void GameOver(){
		GameOverText.text="GameOver";
		GameOverText.gameObject.SetActive (true);
		Time.timeScale = 0;
	}
}






