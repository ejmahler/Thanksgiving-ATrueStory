using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Reaping_Restart : MonoBehaviour {

	public static bool reaping_Start;
	public GameObject Turkey;
	public TextFlasher storyText;
	public GameObject Instructions;
	public int storyProgress;
	public GameObject PlayerSprite;
	public float timer;
	public bool canStart;
	public Sprite Member1;
	public Sprite Member2;
	public Sprite Member3;
	public Sprite Member4;
	public GameObject Family1;
	public GameObject Family2;
	public GameObject Family3;
	public AudioClip TurkeyGobble;
	public Transform TurkeyStart;



	//
	string message;
	public float letterPause = 0.02f;
	//


	// Use this for initialization
	void Start () {
		///
		message = "Humans and Turkeys were locked in an endless struggle.";
        storyText.SetText(message);

        //




        timer = 0.3f;
		canStart = false;
		//storyText.text = "Humans and Turkeys were locked in an endless struggle.";
		PlayerSprite.GetComponent<SpriteRenderer> ().sprite = Member1;
		reaping_Start = false;
	}






	
	// Update is called once per frame
	void Update () {
	
		if (!reaping_Start) {
			timer -= Time.deltaTime;
			if (timer < 0) {
				canStart = true;
			}
		}

		if (canStart) {
			
			if (Input.GetKeyDown (KeyCode.W)) {
				reaping_Start = true;
				canStart = false;
				Instantiate (Turkey, new Vector3 (TurkeyStart.position.x, TurkeyStart.position.y, TurkeyStart.position.z), Quaternion.identity);
				GetComponent<AudioSource> ().PlayOneShot (TurkeyGobble);
				Instructions.SetActive (false);
			} else if (Input.GetKeyDown (KeyCode.S)) {
				reaping_Start = true;
				canStart = false;
				Instantiate (Turkey, new Vector3 (TurkeyStart.position.x, TurkeyStart.position.y, TurkeyStart.position.z), Quaternion.identity);
				GetComponent<AudioSource> ().PlayOneShot (TurkeyGobble);
				Instructions.SetActive (false);
			} else if (Input.GetKeyDown (KeyCode.D)) {
				reaping_Start = true;
				canStart = false;
				Instantiate (Turkey, new Vector3 (TurkeyStart.position.x, TurkeyStart.position.y, TurkeyStart.position.z), Quaternion.identity);
				GetComponent<AudioSource> ().PlayOneShot (TurkeyGobble);
				Instructions.SetActive (false);
			} else if (Input.GetKeyDown (KeyCode.A)) {
				reaping_Start = true;
				canStart = false;
				Instantiate (Turkey, new Vector3 (TurkeyStart.position.x, TurkeyStart.position.y, TurkeyStart.position.z), Quaternion.identity);
				GetComponent<AudioSource> ().PlayOneShot (TurkeyGobble);
				Instructions.SetActive (false);
			}
		}

	}

	public void Reset() {

		reaping_Start = false;
		timer = 0.3f;
		canStart = false;
		//Instructions.SetActive (true);
		storyProgress++;
		ChangeSprites ();

	}
		
	public void ChangeSprites(){
		switch (storyProgress) {
		case 1:
			message = "Turkeys would decent upon hopeless villagers, dragging them away in the night.";
            storyText.SetText(message);


            //storyText.text = "Turkeys would decent upon hopeless villagers, dragging them away in the night.";
            PlayerSprite.GetComponent<SpriteRenderer> ().sprite = Member2;
			Family1.SetActive (false);
			break;

		case 2:
			message = "Entire families disappeared and were never heard from again.";
            storyText.SetText(message);
            //storyText.text = "Entire families disappeared and were never heard from again.";
            PlayerSprite.GetComponent<SpriteRenderer> ().sprite = Member3;
			Family2.SetActive (false);
			break;

		case 3:
			message = "The outlook for humanity was bleak at best...";
            storyText.SetText(message);

            //storyText.text = "The outlook for humanity was bleak at best...";
            PlayerSprite.GetComponent<SpriteRenderer> ().sprite = Member4;
			Family3.SetActive (false);
			break;

		default:
			SceneManager.LoadScene ("StuffTheTurkey");
			break;
		}
	}
}







