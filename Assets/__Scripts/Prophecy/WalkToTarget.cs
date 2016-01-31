using UnityEngine;
using System.Collections;

public class WalkToTarget : MonoBehaviour {

	[SerializeField]
	private Transform target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxisRaw("Vertical") > 0) {

			float speed = GetDistance() / 12 + .04f;

			Vector3 direction = (target.position - transform.position).normalized;
			transform.position += direction * speed * Time.deltaTime;
		}
		float percentCovered = Mathf.InverseLerp (0, 3.5f, GetDistance ());

		float size = Mathf.Lerp (.4f, 1.2f, percentCovered);
		transform.localScale = new Vector3 (size, size, size);
	}

	public float GetDistance() {
		return Vector3.Distance (transform.position, target.position);
	}
}
