using UnityEngine;
using System.Collections;

public class WindMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.localPosition = new Vector3 (this.transform.localPosition.x + .5f, this.transform.localPosition.y, this.transform.localPosition.z);
		if (this.transform.localPosition.x >= 200) {
			this.transform.localPosition = new Vector3 (-135, this.transform.localPosition.y, this.transform.localPosition.z);
		}
	}
}
