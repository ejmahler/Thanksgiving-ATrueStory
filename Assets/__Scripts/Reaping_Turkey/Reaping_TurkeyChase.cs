using UnityEngine;
using System.Collections;

public class Reaping_TurkeyChase : MonoBehaviour {

	public GameObject Target;
	private float speed;
	public GameObject ReapingMaster;
	public Transform StartPosition;
	public Transform StartPosition2;
	private bool facingLeft = true;
//	public AudioClip Person;

	// Use this for initialization
	void Start () {
		ReapingMaster = GameObject.FindGameObjectWithTag ("MainCamera");
		StartPosition = GameObject.FindGameObjectWithTag ("Start1").transform;
		StartPosition2 = GameObject.FindGameObjectWithTag ("Start2").transform;
		Target = GameObject.FindGameObjectWithTag ("Player");
			int startSpot = Random.Range (0, 2);
			if (startSpot == 0) {
			transform.position = StartPosition.position;
			} else if (startSpot == 1) {
				transform.position = StartPosition2.position;
			}

		speed = 2f;
	}
	
	// Update is called once per frame
	void Update () {
	


		//if (Reaping_Restart.reaping_Start) {
			speed += 0.005f;
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards (transform.position, Target.transform.position, step);
		//}

		if (transform.position.x < Target.transform.position.x) {
			if (facingLeft) {
				facingLeft = false;
				Flip ();
			}
		}

		if (transform.position.x > Target.transform.position.x) {
			if (!facingLeft) {
				facingLeft = true;
				Flip ();
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other){

		if (other.gameObject.tag == "Player") {
			other.gameObject.GetComponent<Reaping_PlayerMove> ().PlayYell ();
		//	GetComponent<AudioSource> ().PlayOneShot (Person);
			ReapingMaster.GetComponent<Reaping_Restart> ().Reset ();
			other.gameObject.GetComponent<Reaping_PlayerMove> ().ResetPlayer ();
			Destroy (this.gameObject);
			//speed = 2f;

		}
	}

	void Flip(){
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
		
}
