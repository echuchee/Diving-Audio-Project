using UnityEngine;
using System.Collections;

public class Dolphin : MonoBehaviour {

	public AudioClip clip;
	private double timeToNextPlay;
	private System.Random rand = new System.Random();

	private Quaternion rotation;
	private Vector3 radius = new Vector3(20f,0f,0f);
	private float currentRotation = 0.0f;
	private Vector3 orig;
	public int dolphinFrequency;

	// Use this for initialization
	void Start () {
		GetComponent<AudioSource>().clip = clip;
		orig = this.transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
		if (timeToNextPlay > 0) {
			timeToNextPlay -= Time.deltaTime;
		} else {
			GetComponent<AudioSource>().pitch = (float)(rand.NextDouble() * 0.5 + 0.75);
			timeToNextPlay = rand.NextDouble() * dolphinFrequency + 10; 
			GetComponent<AudioSource>().Play();
		}

		currentRotation -= Time.deltaTime*3f;
		rotation.eulerAngles = new Vector3(0, currentRotation, 0);
		transform.position = (rotation * radius) + orig;
		transform.localRotation = rotation;
	}
}
