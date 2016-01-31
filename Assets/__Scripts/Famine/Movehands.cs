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


	// Use this for initialization
	void Start () {
		StoryText.text = "start";
		LeanTween.init (10000);
	}
	
	// Update is called once per frame
	void Update () {
	
		Debug.Log (canProgress);

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
			StoryText.text = "1";
			LeftInstruction.SetActive (false);
			RightInstruction.SetActive (false);
			HighCorn.SetActive (false);
			break;

		case 2:
			StoryText.text = "2";
			MediumCorn.SetActive (false);
			break;

		case 3:
			StoryText.text = "3";
			LowCorn.SetActive (false);
			break;

		default:
			SceneManager.LoadScene ("");
			break;
		}
	}
}
