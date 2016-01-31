using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour {

	public AudioClip ClickSound;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void BackToMain(){
		GetComponent<AudioSource> ().PlayOneShot (ClickSound);
		SceneManager.LoadScene ("MenuScene");
	}
}
