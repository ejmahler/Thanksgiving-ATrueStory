using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StuffWithMouse : MonoBehaviour {

	public Vector3 mousePosition;

	private int storyProgress;
	private bool storyContinue = false;
	public Text StoryText;
	private bool addCount;
	private int StuffCount;
	public GameObject TurkeyBody;
	public AudioClip Stuff;


	// Use this for initialization
	void Start () {
		StoryText.text = "But through the power of the human spirit, people began to fight back!";
	}
	
	// Update is called once per frame
	void Update () {
	
		Debug.Log (StuffCount);
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
			StoryText.text = "Humans overcame their turkey oppressors!";
			break;

		case 2:
			StoryText.text = "We eat them to remind them of their defeat!";
			break;

		case 3:
			StoryText.text = "We eat them for humanity!";
			break;

		default:
			Application.LoadLevel ("MenuScene");
			break;
		}


	}

	void TurkeyIncrease(){
		TurkeyBody.GetComponent<TurkeyGrow> ().TurkeyScale ();
	}
}
