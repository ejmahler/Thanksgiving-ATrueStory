using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextFlasher : MonoBehaviour {

	private RectTransform blackBackground;
	private Text textBox;
	string message;
	private float letterPause = 0.001f;

	// Use this for initialization
	void Awake () {
		blackBackground = GetComponentInParent<Image> ().GetComponent<RectTransform> ();
		textBox = GetComponent<Text> ();
	}

	IEnumerator TypeText () {
		foreach (char letter in message.ToCharArray()) {
			textBox.GetComponent<Text>().text += letter;
			yield return new WaitForSeconds (letterPause);
		}      
	}
	
	public void SetText(string text) {
		textBox.text = text;
		message = "Humans and Turkeys were locked in an endless struggle.";
		textBox.GetComponent<Text>().text = "";
		StartCoroutine(TypeText ());


		LeanTween.color (blackBackground, Color.gray, .2f).setLoopPingPong (1);
	}
}
