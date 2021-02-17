using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

	private Animator mainAnim,ballAnim;
	void Awake(){
		mainAnim = GameObject.Find ("Main Holder").GetComponent<Animator>();
		ballAnim = GameObject.Find ("Ball Holder").GetComponent<Animator>();
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void PlayButton(){
		SceneManager.LoadScene ("GamePlay");
	}
	public void SelectBall(){
		mainAnim.Play ("FadeOut");
		ballAnim.Play ("FadeIn");
	}
	public void BackToMenu(){
		ballAnim.Play ("FadeOut");
		mainAnim.Play ("FadeIn");
	}
}
