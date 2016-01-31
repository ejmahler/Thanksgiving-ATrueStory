using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextFlasher : MonoBehaviour {

	private RectTransform blackBackground;
	private Text textBox;

	// Use this for initialization
	void Start () {
		blackBackground = GetComponentInParent<Image> ().GetComponent<RectTransform> ();
		textBox = GetComponent<Text> ();
	}
	
	public void SetText(string text) {
		textBox.text = text;

		LeanTween.color (blackBackground, Color.gray, .2f).setLoopPingPong (1);
	}
}
