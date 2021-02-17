using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimerScript : MonoBehaviour {
	public static TimerScript instance;

	Image timerBar;
	public float maxTime = 7f;
	float timeLeft;
	public GameObject timesUpText; 
	// Use this for initialization

	void Awake(){
		if (instance == null)
			instance = this;
		
	}
	void Start () {
		timesUpText.SetActive (false);
		timerBar = GetComponent<Image> ();
		timeLeft = maxTime;
	}
	
	// Update is called once per frame
	void Update () {
		if(PlayerScript.instance.getCanJump()){
		if (timeLeft > 0) {
			timeLeft -= Time.deltaTime;
			timerBar.fillAmount = timeLeft / maxTime;
		} else {
			timesUpText.SetActive (true);
			Time.timeScale = 0;
		}
	}
}
	public void RestartTheTime(){
		timeLeft = maxTime;
	}
}
