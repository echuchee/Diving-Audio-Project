using UnityEngine;
using System.Collections;

public class CoralCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter (Collision col) {
		if (col.gameObject.name == "First Person Controller") {
			if (GetComponent<AudioSource>().isPlaying == false) {
				GetComponent<AudioSource>().Play ();
				//print ("play");
			}
		}

	}
}
