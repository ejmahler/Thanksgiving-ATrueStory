using UnityEngine;
using System.Collections;

public class BibleShot : MonoBehaviour {

	public Rigidbody2D _myRigidbody;
	public float bibleY;
	public float bibleX;


	// Use this for initialization
	void Start () {
		_myRigidbody = GetComponent<Rigidbody2D> ();
		CandyForce ();
	}
	
	// Update is called once per frame
	void Update () {
		//transform.rotation = new Vector3(transform.rotation.x, transform.rotation.y, Random.Range(0,180));
		transform.localScale -= new Vector3 (0.03f, 0.03f, 0f);
		LeanTween.rotateZ (gameObject, Random.Range(-1000,1000),1);

		if (transform.localScale.x < 0) {
			Destroy (this.gameObject);
		}
	
	}

	void CandyForce(){
		bibleX = Random.Range (-5f, 5f);
		bibleY = Random.Range (12f, 15f);
		_myRigidbody.velocity += new Vector2 (bibleX, bibleY);

	}
}
