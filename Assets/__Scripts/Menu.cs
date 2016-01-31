using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void England(){
		Application.LoadLevel ("AMURICA");
	}

	public void Reaper(){
		Application.LoadLevel ("ReapingOfTurkeys");
	}

	public void Witches(){
		Application.LoadLevel ("SacrificingTurkey");
	}

	public void Famine(){
		Application.LoadLevel ("");
	}

	public void Prophecy(){
		Application.LoadLevel ("");
	}

	public void Credits(){

	}
}
