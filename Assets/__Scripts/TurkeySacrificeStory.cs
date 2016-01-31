using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class TurkeySacrificeStory : MonoBehaviour {

	private string[] initialStory = {
		"Every morning on November 1st, the townspeople awake...",
		"...To find a name scorched into the ground.",

	};
	private string[] restOfStory = {
		"Whoever is named by the curse must sacrifice their pet turkey to the witches on Thanksgiving Day...",
		"<i>...Or Else.</i>",
		"The next day, if the witches are satisfied, the scorched name disappears without a trace"
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
	private GameObject blackBackground;
	[SerializeField]
	private GameObject initialBackground;

	private int numStabs = 0;

	private float currentKnifePosition = 0f;

	// Use this for initialization
	IEnumerator Start () {
		storyText.text = initialStory[0];
		instructionText.text = "Press [Space] to continue";

		while (!Input.GetKeyDown (KeyCode.Space)) {
			yield return null;
		}
		blackBackground.SetActive (false);
		storyText.text = initialStory[1];

		yield return new WaitForSeconds (.5f);

		while (!Input.GetKeyDown (KeyCode.Space)) {
			yield return null;
		}
		initialBackground.SetActive (false);

		instructionText.text = "Move the mouse left and right to sacrifice the turkey";
		StartCoroutine (WatchForStabs ());

		foreach (string storyItem in restOfStory) {
			storyText.text = storyItem;

			yield return new WaitForSeconds (3);

			numStabs = 0;
			yield return StartCoroutine (WaitForStabs (3));
		}

		//story is over
		var result = SceneManager.LoadSceneAsync("ThrowCandy", LoadSceneMode.Single);
		result.allowSceneActivation = true;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 knifePos = knifeObj.localPosition;
		knifePos.x = Mathf.Clamp (knifeObj.parent.InverseTransformPoint(Camera.main.ScreenToWorldPoint (Input.mousePosition)).x * .75f, minKnifeX, maxKnifeX);
		knifeObj.localPosition = knifePos;

		currentKnifePosition = Mathf.InverseLerp (minKnifeX, maxKnifeX, knifePos.x);
	}

	private IEnumerator WatchForStabs() {
		while(true) {
			while (currentKnifePosition < .75f) {
				yield return null;
			}
			GetComponent<AudioSource> ().Play ();
			while (currentKnifePosition > .25f) {
				yield return null;
			}
			numStabs++;
		}
	}

	private IEnumerator WaitForStabs(int count) {
		for (int i = 0; i < count; i++) {
			while (numStabs == 0) {
				yield return null;
			}
			numStabs--;
		}
	}
}
