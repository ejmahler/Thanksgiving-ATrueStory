﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StuffWithMouse : MonoBehaviour {

	public Vector3 mousePosition;

	private int storyProgress;
	private bool storyContinue = false;
	public TextFlasher StoryText;
	private bool addCount;
	private int StuffCount;
	public GameObject TurkeyBody;
	public AudioClip Stuff;
	public GameObject Mouse;
	public GameObject UpArrow;
	public GameObject DownArrow;


	// Use this for initialization
	void Start () {
		StoryText.SetText("But through the power of the human spirit, people began to fight back!");
	}
	
	// Update is called once per frame
	void Update () {

		mousePosition = Input.mousePosition;
		mousePosition = Camera.main.ScreenToWorldPoint (mousePosition);
		transform.position = new Vector3 (transform.position.x, mousePosition.y, transform.position.z);
		if (transform.position.y > 0) {
			transform.position = new Vector3 (transform.position.x, 0, transform.position.z);
			if (addCount) {
				GetComponent<AudioSource> ().PlayOneShot (Stuff);
				addCount = false;
				TurkeyIncrease ();
				StuffCount++;
				if (StuffCount >= 5) {
					storyContinue = true;
					StuffCount = 0;
				}
			}
			if(storyContinue){
				storyProgress++;
				NextText ();
				storyContinue = false;
			}

		}

		if (transform.position.y < -5) {
			transform.position = new Vector3 (transform.position.x, -5, transform.position.z);
		}

		if (mousePosition.y < 0){
			addCount = true;
		}

	}

	void NextText(){
		switch (storyProgress){

		case 1:
            StoryText.SetText("Humans overcame their turkey oppressors!");
			Mouse.SetActive (false);
			UpArrow.SetActive (false);
			DownArrow.SetActive (false);
			break;

		case 2:
            StoryText.SetText("We eat them to remind them of their defeat!");
			break;

		case 3:
            StoryText.SetText("We eat them for humanity!");
			break;

		default:
			SceneManager.LoadScene ("MenuScene");
			break;
		}


	}

	void TurkeyIncrease(){
		TurkeyBody.GetComponent<TurkeyGrow> ().TurkeyScale ();
	}
}
