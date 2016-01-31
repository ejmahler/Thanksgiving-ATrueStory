using UnityEngine;
using System.Collections;

public class CandyThrowRedo : MonoBehaviour {

	public Rigidbody2D _myRigidbody;
	public float candyY;
	public float candyX;


	// Use this for initialization
	void Start () {
		_myRigidbody = GetComponent<Rigidbody2D> ();
		CandyForce ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.localScale -= new Vector3 (0.03f, 0.03f, 0f);
		LeanTween.rotateZ (gameObject, Random.Range(-1000,1000),1);

		if (transform.localScale.x < 0) {
			Destroy (this.gameObject);
		}

	}

	void CandyForce(){
		candyX = Random.Range (-5f, 5f);
		candyY = Random.Range (12f, 15f);
		_myRigidbody.velocity += new Vector2 (candyX, candyY);

	}
}
