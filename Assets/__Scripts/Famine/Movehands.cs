using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Movehands : MonoBehaviour {

	public GameObject RightHand;
	public GameObject Lefthand;
	public GameObject Bible;
	public Transform BibleStart;
	private bool canProgress;
	private int storyProgress;
	public Text StoryText;
	public GameObject LeftInstruction;
	public GameObject RightInstruction;
	public GameObject HighCorn;
	public GameObject MediumCorn;
	public GameObject LowCorn;
	public AudioClip Heaven;


	// Use this for initialization
	void Start () {
		StoryText.text = "On Thursday, late in November, God instructed the villagers to trade their corn for bibles. ";
		LeanTween.init (10000);
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.LeftShift)) {
			Lefthand.transform.position += new Vector3 (0.01f, 0, 0);
		} else {
			Lefthand.transform.position += new Vector3 (-0.01f, 0, 0);
		}

		if (Input.GetKey (KeyCode.RightShift)) {
			RightHand.transform.position += new Vector3 (-0.01f, 0, 0);
		} else {
			RightHand.transform.position += new Vector3 (0.01f, 0, 0);
		}

		if (Lefthand.transform.position.x < -1.5f) {
			Lefthand.transform.position = new Vector3 (-1.5f, Lefthand.transform.position.y, Lefthand.transform.position.z);
		}

		if (Lefthand.transform.position.x > -0.6) {
			Lefthand.transform.position = new Vector3 (-0.6f, Lefthand.transform.position.y, Lefthand.transform.position.z);
		}

		if (RightHand.transform.position.x < 0.6f) {
			RightHand.transform.position = new Vector3 (0.6f, Lefthand.transform.position.y, Lefthand.transform.position.z);
		}

		if (RightHand.transform.position.x > 1.5f) {
			RightHand.transform.position = new Vector3 (1.5f, Lefthand.transform.position.y, Lefthand.transform.position.z);
		}



		if (RightHand.transform.position.x < 0.7 && Lefthand.transform.position.x > -0.7) {
			Instantiate (Bible, new Vector3 (BibleStart.position.x, BibleStart.position.y, BibleStart.position.z), Quaternion.identity);
			if (canProgress) {
				GetComponent<AudioSource> ().PlayOneShot (Heaven);
				storyProgress++;
				canProgress = false;
				NextText ();
			}
		} else {
			canProgress = true;
		}

	}

	void NextText(){
		switch (storyProgress){

		case 1:
			StoryText.text = "\"but what will we eat?\", the villagers asked. ";
			LeftInstruction.SetActive (false);
			RightInstruction.SetActive (false);
			HighCorn.SetActive (false);
			break;

		case 2:
			StoryText.text = "\"I will provide.\", God replied.";
			MediumCorn.SetActive (false);
			break;

		case 3:
			StoryText.text = "The villagers obeyed with trepidation.";
			LowCorn.SetActive (false);
			break;

		default:
			SceneManager.LoadScene ("MenuScene");
			break;
		}
	}
}
