using UnityEngine;
using System.Collections;
using System;

public class SeafloorStepsound : MonoBehaviour {

	private double timeToNextPlay;
	//private System.Random rand = new System.Random();
	Vector3 floorPos;
	CharacterController player;
	GameObject self;

	// Use this for initialization
	void Start () {
		floorPos = GameObject.Find("floor").transform.position;
		player = GameObject.Find("First Person Controller").GetComponent<CharacterController>();
		self = GameObject.Find("Seafloor Stepsound");
	}
	
	// Update is called once per frame
	void Update () {
		if (timeToNextPlay > 0) {
			timeToNextPlay -= Time.deltaTime;
		} else {
			Vector3 playerPos = player.transform.position;
			Vector3 diffVec = playerPos - floorPos;
			float diffY = diffVec.y;

			timeToNextPlay = 0.5;

			if (diffY < 1.25f && player.velocity.magnitude > 1) { // 1 is the absolute closest the player can get (touching the seafloor)
				self.transform.position = new Vector3(playerPos.x, floorPos.y, playerPos.z);
				GetComponent<AudioSource>().Play();
			}
		}
	}
}
