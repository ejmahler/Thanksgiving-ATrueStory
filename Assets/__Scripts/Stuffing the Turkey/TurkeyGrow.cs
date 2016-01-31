using UnityEngine;
using System.Collections;

public class TurkeyGrow : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void TurkeyScale(){
		transform.localScale += new Vector3 (0.03f, 0.03f, 0f);
	}
}
