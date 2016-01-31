using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MuricaStoryControl : MonoBehaviour {
	private string[] turkeyPartyStory = {
		"Back during the American Revolution, soldiers took any psychological advantage they could find.",
		"At the time, turkeys were considered sacred by the Church of England.",
		"Eager to stick it to the Brits, brave American soldiers staged the Boston Turkey Party",
		"They dumped case after case of british Turkeys into the water."
	};

	[SerializeField]
	private Text storyMesh;

	[SerializeField]
	private Text instructionMesh;

	private int turkeyDrops = 0;

	// Use this for initialization
	IEnumerator Start () {

		instructionMesh.text = "Drag boxes of turkey and drop them into the water.";

		foreach (string storyItem in turkeyPartyStory) {
			storyMesh.text = storyItem;

			yield return new WaitForSeconds (1f);

			while (turkeyDrops == 0) {
				yield return null;
			}
			GetComponent<AudioSource> ().Play ();
			turkeyDrops--;
		}

		//story is over
		var result = SceneManager.LoadSceneAsync("MIDDLE_FINGER_TO_QUEEN_GO_MURICA", LoadSceneMode.Single);
		result.allowSceneActivation = true;
	}
	
	public void DropTurkey()
	{
		turkeyDrops++;
	}

}
