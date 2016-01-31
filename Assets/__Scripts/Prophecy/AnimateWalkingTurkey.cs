using UnityEngine;
using System.Collections;

public class AnimateWalkingTurkey : MonoBehaviour {

	[SerializeField]
	private float framesPerSecond;

	[SerializeField]
	private Sprite[] frames;

	private float currentFrame = 0f;

	private bool walking = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (!walking && Input.GetAxisRaw("Vertical") > 0) {
			currentFrame = Mathf.Ceil (currentFrame);
			walking = true;
		}
		if (Input.GetAxisRaw ("Vertical") > 0) {
			currentFrame += Time.deltaTime * framesPerSecond;
		} else {
			walking = false;
		}

		GetComponent<SpriteRenderer> ().sprite = frames [Mathf.FloorToInt (currentFrame) % frames.Length];
	}
}
