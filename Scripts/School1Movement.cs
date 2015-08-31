using UnityEngine;
using System.Collections;

public class School1Movement : MonoBehaviour {

	private Quaternion rotation;
	private Vector3 radius = new Vector3(20f,0f,0f);
	private float currentRotation = 0.0f;
	private Vector3 orig;
	// Use this for initialization
	void Start () {
		orig = this.transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
		//Vector3 curr = this.transform.localPosition;
		//this.transform.localPosition = new Vector3 (curr.x, curr.y, curr.z);
		currentRotation -= Time.deltaTime*15;
		rotation.eulerAngles = new Vector3(0, currentRotation, 0);
		transform.position = (rotation * radius) + orig;
		transform.localRotation = rotation;


	}
}
