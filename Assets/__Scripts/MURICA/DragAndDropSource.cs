using UnityEngine;
using System.Collections;

public class DragAndDropSource : MonoBehaviour {

	[SerializeField]
	private GameObject draggedItemPrefab;

	[SerializeField]
	private GameObject target;


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
		var obj = Instantiate (draggedItemPrefab);

		while (Input.GetMouseButton (0)) {
			yield return null;
		}

		var mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		var hit = Physics2D.OverlapPoint (mousePosition);
		if (hit != null && hit.gameObject == target) {
			target.GetComponent<MuricaStoryControl> ().DropTurkey ();
			Destroy (obj);
		} else {
			LeanTween.move (obj, transform.position, .25f).setOnComplete (() => {
				Destroy (obj);
			});
		}
	}
}
