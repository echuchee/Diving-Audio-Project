using UnityEngine;
using System.Collections;
using System;

public class Dog : MonoBehaviour {

	public AudioClip[] clips = new AudioClip[3];
	public AudioClip pantingSound;
	private double timeToNextPlay = 0;
	private System.Random rand = new System.Random();
	
	private float distance = 0.0f;
	private GameObject player;
	private bool panting = false;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("First Person Controller");
	
	}
	
	// Update is called once per frame
	void Update () {


		distance = Vector3.Distance (player.transform.position, this.transform.position);
		if (distance < 5.1) {
			panting = true;
			GetComponent<AudioSource>().volume = .1f;
			GetComponent<AudioSource>().clip = pantingSound; 
			if (GetComponent<AudioSource>().isPlaying == false) {
				GetComponent<AudioSource>().Play ();
			}
		}
		else {
			if (panting == true) {
				GetComponent<AudioSource>().Pause();
				panting = false;
			}
			GetComponent<AudioSource>().volume = 1;
			if (timeToNextPlay > 0) {
				timeToNextPlay -= Time.deltaTime;
			} else {
				timeToNextPlay = rand.NextDouble() * 6;
				//audio.PlayOneShot(clips[rand.Next (3)]);
				GetComponent<AudioSource>().clip = clips[rand.Next(3)];
				GetComponent<AudioSource>().Play();
			}
		}
	}
}
