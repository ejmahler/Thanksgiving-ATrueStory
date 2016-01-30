using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MuricaStoryControl : MonoBehaviour {
	private string[] turkeyPartyStory = {
		"Back during the American Revolution, soldiers took any psychological advantage they could find.",
		"At the time, turkeys were considered sacred by the Church of England.",
		"Eager to stick it to the Brits, brave American soldiers staged the Boston Turkey Party",
		"They dumped case after case of british Turkeys into the water."
	};

	[SerializeField]
	private GameObject turkeyBoxPrefab;

	[SerializeField]
	private Text storyMesh;

	[SerializeField]
	private Vector3 turkeySpawnLocation;

	public bool HasBeenDropped { get; set; }

	// Use this for initialization
	IEnumerator Start () {
		foreach (string storyItem in turkeyPartyStory) {
			storyMesh.text = storyItem;

			yield return new WaitForSeconds (1f);

			Instantiate (turkeyBoxPrefab);

			while (!HasBeenDropped) {
				yield return null;
			}
		}

		//story is over
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
