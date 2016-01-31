using UnityEngine;
using System.Collections;

public class DragAndDropItem : MonoBehaviour {

	[SerializeField]
	private float z = -1;

	// Use this for initialization
	IEnumerator Start () {
		while (Input.GetMouseButton (0)) {
			Vector3 position = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			position.z = z;
			transform.position = position;
			yield return null;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
