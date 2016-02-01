using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class QueenStoryControl : MonoBehaviour {
	private string[] turkeyPartyStory = {
		"The Brits' sprit was crushed.",
		"We successfuly gave the middle finger to the Queen.",
		"Every Thanksgiving, we eat turkey to commemorate this victory"
	};

	[SerializeField]
	private Text instructionContainer;
	[SerializeField]
	private TextFlasher storyMesh;

	[SerializeField]
	private SpriteRenderer fistSprite;
	[SerializeField]
	private Sprite fingerSprite;



	private int storyIndex = 0;
	private float fistY = 0;

	// Use this for initialization
	IEnumerator Start () {
		instructionContainer.text = "Mash [Space] to raise your fist";

		fistSprite.GetComponent<AudioSource> ().pitch = .8f;

		while (fistY < 4.5) {
			float fistChange = .15f;
			if (Input.GetKeyDown (KeyCode.Space)) {
				fistY += fistChange;
				fistSprite.transform.position += new Vector3 (0, fistChange);
				fistSprite.GetComponent<AudioSource> ().pitch += .01f;
				fistSprite.GetComponent<AudioSource> ().Play ();
			}
			yield return null;
		}
		storyIndex++;

		instructionContainer.text = "Press [Enter] to give the Queen the middle finger";
		while (!Input.GetKeyDown (KeyCode.Return)) {
			yield return null;
		}
		storyIndex++;
		fistSprite.sprite = fingerSprite;

		GetComponent<AudioSource> ().Play ();

		instructionContainer.text = "Press [Esc] to return to the main menu";

		while (true) {
			Vector3 randomDiff = Random.insideUnitCircle;

			LeanTween.move (fistSprite.gameObject, fistSprite.transform.position + randomDiff, 1f).setLoopPingPong (1);
			yield return new WaitForSeconds (2f);
		}


	}
	
	// Update is called once per frame
	void Update () {
		if (storyIndex >= turkeyPartyStory.Length - 1 && Input.GetKeyDown(KeyCode.Escape)) {
			SceneManager.LoadSceneAsync("MenuScene");
		}
		storyMesh.SetText(turkeyPartyStory [storyIndex]);
	}
}
