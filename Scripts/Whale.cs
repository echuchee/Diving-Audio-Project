using UnityEngine;
using System.Collections;
using System;

public class Whale : MonoBehaviour {

	public AudioClip farClip;
	public AudioClip closeClip;
	private double timeToNextPlay;
	private System.Random rand = new System.Random();

	private Quaternion rotation;
	private Vector3 radius = new Vector3(20f,0f,0f);
	private float currentRotation = 0.0f;
	private Vector3 orig;

	private GameObject player;
	private float distance = 0.0f;

	public int whaleSoundFreq;

	// Use this for initialization
	void Start () {
		GetComponent<AudioSource>().clip = farClip;
		orig = this.transform.localPosition;
		player = GameObject.Find ("First Person Controller");
	}
	
	// Update is called once per frame
	void Update () {
		distance = Vector3.Distance (player.transform.position, this.transform.position);

		if (distance > 20) {
			GetComponent<AudioSource>().clip = farClip;
		}
		else {
			GetComponent<AudioSource>().clip = closeClip;
		}
		if (timeToNextPlay > 0) {
			timeToNextPlay -= Time.deltaTime;
		} else {
			GetComponent<AudioSource>().pitch = (float)(rand.NextDouble() * 0.5 + 0.75);
			timeToNextPlay = rand.NextDouble() * whaleSoundFreq + 10; 
			GetComponent<AudioSource>().Play();
		}

		currentRotation += Time.deltaTime*2.5f;
		rotation.eulerAngles = new Vector3(0, currentRotation, 0);
		transform.position = (rotation * radius) + orig;
		transform.localRotation = rotation;
	}
}
