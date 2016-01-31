using UnityEngine;
using System.Collections;

public class DragAndDropSource : MonoBehaviour {

	public GameObject target;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			var mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			var hit = Physics2D.OverlapPoint (mousePosition);
			if(hit != null && hit.gameObject == gameObject) {
				StartCoroutine (DoDragAndDrop ());
			}
		}
	}

	private IEnumerator DoDragAndDrop()
	{
		var boxes = GetComponentsInChildren<DragAndDropItem> ();

		var obj = boxes [0].gameObject;
		obj.transform.parent = null;
		obj.GetComponent<AudioSource> ().Play ();

		while (Input.GetMouseButton (0)) {
			Vector3 position = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			position.z = -1f;
			obj.transform.position = position;
			yield return null;
		}

		var mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		var hit = Physics2D.OverlapPoint (mousePosition);
		if (hit != null && hit.gameObject == target) {
			Destroy (obj);
			GetComponent<AudioSource> ().Play ();

			if (boxes.Length == 1) {
				target.GetComponent<MuricaStoryControl> ().DropTurkey ();
				GetComponent<Collider2D> ().enabled = false;
				Destroy (gameObject, 1f);
			}
		} else {
			LeanTween.move (obj, transform.position, .25f).setOnComplete (() => {
				obj.transform.SetParent(transform, true);
			});
		}
	}
}
