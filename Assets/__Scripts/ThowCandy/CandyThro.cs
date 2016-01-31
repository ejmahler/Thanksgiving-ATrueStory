using UnityEngine;
using System.Collections;

public class CandyThro : MonoBehaviour {

	public bool candyThrown;
	public Rigidbody2D _myRigidbody;
	public Transform StartLocation;
	public bool candyLaunched;
	public float candyY;
	public float candyX;
	public float rotateSpeed;

	// Use this for initialization
	void Start () {
		_myRigidbody = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
	
		if (candyThrown) {
			transform.localScale -= new Vector3 (0.05f, 0.05f, 0f);
			LeanTween.rotateZ (gameObject, 1000, 5);
			_myRigidbody.isKinematic = false;
			if (!candyLaunched) {
				CandyForce ();
				candyLaunched = true;
			}
		}

		if (transform.localScale.x < 0.1) {
			transform.localScale = new Vector3 (1, 1, 1);
			_myRigidbody.isKinematic = true;
			transform.position = StartLocation.position;
			candyThrown = false;
			candyLaunched = false;
		}

	}


	void CandyForce(){
		candyX = Random.Range (-1f, 1f);
		candyY = Random.Range (6f, 12f);
		_myRigidbody.velocity += new Vector2 (candyX, candyY);

	}
}
