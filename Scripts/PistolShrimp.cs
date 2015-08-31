using UnityEngine;
using System.Collections;
using System;

public class PistolShrimp : MonoBehaviour {

	private double timeToNextPlay;
	private System.Random rand = new System.Random();
	Vector3 floorPos;
	GameObject player;
	GameObject self;
	Vector3 playerPos;

	// Use this for initialization
	void Start () {
		floorPos = GameObject.Find("floor").transform.position;
		player = GameObject.Find("First Person Controller");
		self = GameObject.Find("Pistol Shrimp Sound");
		playerPos = player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (timeToNextPlay > 0) {
			timeToNextPlay -= Time.deltaTime;
		} else {
			playerPos = player.transform.position;
			Vector3 diffVec = playerPos - floorPos;
			float diffY = diffVec.y;

			// Closer to the seafloor, the more frequent the snapping, but not more than 15 seconds between
			timeToNextPlay = Math.Min(15, rand.NextDouble() * diffY * 3 + 1);

			if (diffY < 3.5f) { // 1 is the absolute closest the player can get (touching the seafloor)
				self.transform.position = new Vector3(playerPos.x, floorPos.y, playerPos.z);
				GetComponent<AudioSource>().Play();
			}
		}
	}
}
