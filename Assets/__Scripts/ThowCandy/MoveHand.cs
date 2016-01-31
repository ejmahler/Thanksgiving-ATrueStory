using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MoveHand : MonoBehaviour {


	public float maxSpeed;
	public Rigidbody2D _myRigidbody;
	public GameObject Candy;
	public Transform CandyStart;
	public int storyProgress;
	public Text StoryText;
	private int candyThrown;
	public AudioClip Cheer;


	// Use this for initialization
	void Start () {
		_myRigidbody = GetComponent<Rigidbody2D> ();
		StoryText.text = "After a century of  heartbreak, the townspeople realized that candy was the answer!";
		LeanTween.init (5000);
	}


	void FixedUpdate(){
		float moveX = Input.GetAxis ("Horizontal");
		_myRigidbody.velocity = new Vector2 (moveX * maxSpeed, _myRigidbody.velocity.y);
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Space)) {
			for(int i = 0; i < 8; i++){
			Instantiate (Candy, new Vector3 (CandyStart.position.x, CandyStart.position.y, CandyStart.position.z), Quaternion.identity);
			}
			candyThrown++;
			if (candyThrown > 4) {
				storyProgress++;
				NextText ();
				candyThrown = 0;
			}
			GetComponent<AudioSource> ().PlayOneShot (Cheer);
		}
	
	}

	void NextText(){
		switch (storyProgress){

		case 1:
			StoryText.text = "They could nullify the witches power by having kids dress up as witches, monsters, and other scary things.";
			break;

		case 2:
			StoryText.text = "So every year on Thanksgiving, to celebrate not having to sacrifice our turkeys...";
			break;

		case 3:
			StoryText.text = "we eat our turkeys.";
			break;

		default:
			Application.LoadLevel ("MenuScene");
			break;
		}
	}
}
