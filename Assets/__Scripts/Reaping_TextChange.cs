using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Reaping_TextChange : MonoBehaviour {

	private string Text1 = "text1";
	private string Text2 = "text2";
	private string Text3 = "text3";
	public Text _myText;

	// Use this for initialization
	void Start () {
	
		_myText = GetComponent<Text> ();


	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void NextText() {

		Debug.Log ("Change the Text");

	}
}
