using UnityEngine;
using UnityEngine.UI;
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
	private Text storyMesh;

	[SerializeField]
	private SpriteRenderer fistSprite;
	[SerializeField]
	private Sprite fingerSprite;



	private int storyIndex = 0;
	private int fistY = 0;

	// Use this for initialization
	IEnumerator Start () {
		instructionContainer.text = "Mash [Space] to raise your fist";
		yield return null;

		float initialFistY = fistSprite.transform.position.y;
	
	}
	
	// Update is called once per frame
	void Update () {
		if (storyIndex >= turkeyPartyStory.Length) {
			storyIndex = turkeyPartyStory.Length - 1;
		}
		storyMesh.text = turkeyPartyStory [storyIndex];
	}
}
