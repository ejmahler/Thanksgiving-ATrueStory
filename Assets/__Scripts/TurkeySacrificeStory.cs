using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TurkeySacrificeStory : MonoBehaviour {

	private string initialStory = "something about a burned name";
	private string[] restOfStory = {
		"kid has to sacrifice",
		"[i]...or else[/i]",
		"on the day after thanksgiving, if the witches were satisfied, the scorched name disappeared without a trace"
	};

	[SerializeField]
	private Transform knifeObj;

	[SerializeField]
	private float minKnifeX;
	[SerializeField]
	private float maxKnifeX;

	[SerializeField]
	private Text storyText;
	[SerializeField]
	private Text instructionText;

	[SerializeField]
	private GameObject initialBackground;

	private float currentKnifePosition = 0f;

	// Use this for initialization
	IEnumerator Start () {
		storyText.text = initialStory;

		yield return StartCoroutine (WaitForStabs (2));

		foreach (string storyItem in restOfStory) {
			storyText.text = storyItem;

			yield return StartCoroutine (WaitForStabs (2));
		}
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 knifePos = knifeObj.localPosition;
		knifePos.x = Mathf.Clamp (knifeObj.parent.InverseTransformPoint(Camera.main.ScreenToWorldPoint (Input.mousePosition)).x * .75f, minKnifeX, maxKnifeX);
		knifeObj.localPosition = knifePos;

		currentKnifePosition = Mathf.InverseLerp (minKnifeX, maxKnifeX, knifePos.x);
	}

	private IEnumerator WaitForStabs(int numStabs) {
		for (int i = 0; i < numStabs; i++) {
			while (currentKnifePosition < .75f) {
				yield return null;
			}
			while (currentKnifePosition > .25f) {
				yield return null;
			}
		}
	}
}
