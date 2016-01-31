using UnityEngine;
using System.Collections;

public class Reaping_PlayerMove : MonoBehaviour {

	public float maxSpeed;
	public Rigidbody2D _myRigidbody;
	public Transform PlayerStart;


	// Use this for initialization
	void Start () {
		_myRigidbody = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate() {

		if (Reaping_Restart.reaping_Start) {
			float moveX = Input.GetAxis ("Horizontal");
			float moveY = Input.GetAxis ("Vertical");
			_myRigidbody.velocity = new Vector2 (moveX * maxSpeed, moveY * maxSpeed);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ResetPlayer(){
		_myRigidbody.velocity = new Vector2 (0f, 0f);
		transform.position = PlayerStart.position;
	}


}
