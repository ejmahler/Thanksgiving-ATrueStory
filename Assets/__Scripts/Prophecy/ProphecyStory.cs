using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class ProphecyStory : MonoBehaviour {
	[SerializeField]
	private AudioSource[] music;
	private float[] mixes;

	[SerializeField]
	private WalkToTarget walker;


	[SerializeField]
	private GameObject effectPrefab;

	[SerializeField]
	private CanvasGroup group;

	[SerializeField]
	private TextFlasher storyText;


	// Use this for initialization
	IEnumerator Start () {
		mixes = new float[music.Length];

		mixes [0] = 1f;

		storyText.text = "";

		while (!(Input.GetAxisRaw("Vertical") > 0)) {
			yield return null;
		}
		LeanTween.value (gameObject, 0f, 1f, .5f).setOnUpdate ((val) => {
			MixUp(1, val);
		});



		storyText.text = "It has been foretold";
		while (walker.GetDistance () > 1.5) {
			yield return null;
		}
		LeanTween.value (gameObject, 0f, 1f, .5f).setOnUpdate ((val) => {
			MixUp(2, val);
		});



		storyText.text = "Thanksgiving has always been";
		while (walker.GetDistance () > .7) {
			yield return null;
		}
		LeanTween.value (gameObject, 0f, 1f, .5f).setOnUpdate ((val) => {
			MixUp(3, val);
		});

		storyText.text = "And always it will be";
		while (walker.GetDistance () > .1) {
			yield return null;
		}
		LeanTween.value (gameObject, 0f, 1f, .5f).setOnUpdate ((val) => {
			MixUp(4, val);
		});
		storyText.text = "The Turkey will guide us to the Light";

		var obj = Instantiate<GameObject> (effectPrefab);
		obj.transform.position = new Vector3 ();
		obj.GetComponent<Renderer> ().material.color = new Color(1,1,1,0);
		LeanTween.alpha (obj, 1f, 5f).setEase (LeanTweenType.easeInCubic);
		LeanTween.value (gameObject, 1f, 0f, 5f).setOnUpdate ((val) => group.alpha = val);

		yield return new WaitForSeconds (10f);
		SceneManager.LoadSceneAsync("MenuScene");
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < music.Length; i++) {
			music [i].volume = mixes [i];
		}
	}

	private void MixUp(int index, float volume)
	{
		mixes [index] = volume;

		for (int i = 0; i < mixes.Length; i++) {
			if (i != index) {
				if (mixes [i] > 0) {
					mixes [i] = 1 - volume;
				}
			}
		}
	}
}
