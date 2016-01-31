using UnityEngine;
using System.Collections;

public class Reaping_TurkeyChase : MonoBehaviour {

	public Transform Target;
	private float speed;
	public GameObject ReapingMaster;
	public Transform StartPosition;
	public Transform StartPosition2;
	private bool facingLeft = true;
	public AudioClip Person;

	// Use this for initialization
	void Start () {
		speed = 2f;
	}
	
	// Update is called once per frame
	void Update () {
	
		speed += 0.005f;

		if (Reaping_Restart.reaping_Start) {
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards (transform.position, Target.position, step);
		}

		if (transform.position.x < Target.position.x) {
			if (facingLeft) {
				facingLeft = false;
				Flip ();
			}
		}

		if (transform.position.x > Target.position.x) {
			if (!facingLeft) {
				facingLeft = true;
				Flip ();
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other){

		if (other.gameObject.tag == "Player") {
			GetComponent<AudioSource> ().PlayOneShot (Person);
			ReapingMaster.GetComponent<Reaping_Restart> ().Reset ();
			other.gameObject.GetComponent<Reaping_PlayerMove> ().ResetPlayer ();
			speed = 2f;
			int startSpot = Random.Range (0, 2);
			if (startSpot == 0) {
				transform.position = StartPosition.position;
			} else if (startSpot == 1) {
				transform.position = StartPosition2.position;
			}
		}
	}

	void Flip(){
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
		
}
