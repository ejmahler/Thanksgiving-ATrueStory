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
	private TextFlasher storyMesh;

	[SerializeField]
	private Text instructionMesh;

	[SerializeField]
	private GameObject dragSourcePrefab;

	private int turkeyDrops = 0;

	// Use this for initialization
	IEnumerator Start () {

		instructionMesh.text = "Drag boxes of turkey and drop them into the water.";

		foreach (string storyItem in turkeyPartyStory) {
			storyMesh.SetText(storyItem);

			yield return new WaitForSeconds (1f);

			while (turkeyDrops == 0) {
				yield return null;
			}
			turkeyDrops--;
		}

		//story is over
		var result = SceneManager.LoadSceneAsync("MIDDLE_FINGER_TO_QUEEN_GO_MURICA", LoadSceneMode.Single);
		result.allowSceneActivation = true;
	}
	
	public void DropTurkey()
	{
		turkeyDrops++;

		var newSource = Instantiate<GameObject> (dragSourcePrefab);
		newSource.transform.position = new Vector3 (-10, -3.6f, -1);
		LeanTween.moveX (newSource, -3.5f, 2f);

		newSource.GetComponent<DragAndDropSource> ().target = gameObject;
	}
}



