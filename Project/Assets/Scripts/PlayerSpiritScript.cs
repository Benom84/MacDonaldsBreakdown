using UnityEngine;
using System.Collections;

public class PlayerSpiritScript : MonoBehaviour {

	public float horSpeed = 0.2f;
	public float verSpeed = 0.2f;
	public float horBoundry = 1f;
	public float verBoundry = 15f;

	private float center;
	private Vector3 goalPos;
	private float z;
	private float lerpAdd = 0.3f;

	void Awake () {
		center = transform.position.x;
		z = transform.position.z;

		goalPos = new Vector3 (center - horBoundry, transform.position.y + verSpeed, z);
	}
	
	// Update is called once per frame
	void Update () {

		float y = transform.position.y;
		if (transform.position.x > (center + horBoundry - 0.1)) {
			Vector3 currScale = transform.localScale;
			currScale.x *= -1;
			transform.localScale = currScale;
			goalPos = new Vector3 (center - horBoundry - lerpAdd, y + verSpeed, z);
		}
		else if (transform.position.x < (center - horBoundry + 0.1)) {
			Vector3 currScale = transform.localScale;
			currScale.x *= -1;
			transform.localScale = currScale;
			goalPos = new Vector3 (center + horBoundry + lerpAdd, y + verSpeed, z);
		}
		transform.position = Vector3.Lerp (transform.position, goalPos, horSpeed * Time.deltaTime);

		if (y > verBoundry)
						GameObject.Destroy (gameObject);
	
	}
}
