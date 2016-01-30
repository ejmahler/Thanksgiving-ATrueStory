using UnityEngine;
using System.Collections;

public class Reaping_TurkeyChase : MonoBehaviour {

	public Transform Target;
	public float speed;
	public GameObject TextHolder;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, Target.position, step);

	}

	void OnTriggerEnter2D(Collider2D other){

		if (other.gameObject.tag == "Player") {
			TextHolder.GetComponent<Reaping_TextChange> ().NextText ();
		}
	}
}
