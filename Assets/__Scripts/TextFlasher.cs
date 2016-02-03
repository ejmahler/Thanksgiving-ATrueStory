using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextFlasher : MonoBehaviour {

	private RectTransform blackBackground;
	private Text textBox;
    private string targetText;
	private float letterPause = 0.001f;

	// Use this for initialization
	void Awake () {
		blackBackground = GetComponentInParent<Image> ().GetComponent<RectTransform> ();
		textBox = GetComponent<Text> ();
	}

	IEnumerator TypeText (string message) {
        int i = 0;
		foreach (char letter in message.ToCharArray()) {
            i++;
			textBox.GetComponent<Text>().text += letter;
            if(i%8 == 0)
			    yield return new WaitForSeconds (letterPause);
		}      
	}

    public string text {
        set
        {
            SetText(value);
        }
    }
	
	public void SetText(string text) {
        if (targetText != text)
        {
            targetText = text;
            textBox.GetComponent<Text>().text = "";
            StartCoroutine(TypeText(text));


            LeanTween.color(blackBackground, Color.gray, .2f).setLoopPingPong(1);
        }
	}
}
