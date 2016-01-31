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
		transform.localScale += new Vector3 (1.1f, 1.1f, 1f);
	}
}
