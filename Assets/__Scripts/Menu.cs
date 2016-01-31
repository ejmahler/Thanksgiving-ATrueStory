using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	public AudioClip Select;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void England(){
		GetComponent<AudioSource> ().PlayOneShot (Select);
		SceneManager.LoadScene ("AMURICA");

	}

	public void Reaper(){
		GetComponent<AudioSource> ().PlayOneShot (Select);
		SceneManager.LoadScene ("ReapingOfTurkeys");

	}

	public void Witches(){
		GetComponent<AudioSource> ().PlayOneShot (Select);
		SceneManager.LoadScene ("SacrificingTurkey");
	}

	public void Famine(){
		GetComponent<AudioSource> ().PlayOneShot (Select);
		SceneManager.LoadScene ("FamineHands");
	}

	public void Prophecy(){
		GetComponent<AudioSource> ().PlayOneShot (Select);
		SceneManager.LoadScene ("TheProphecy");
	}

	public void Credits(){
		GetComponent<AudioSource> ().PlayOneShot (Select);
		SceneManager.LoadScene ("Credits");
	}
}
