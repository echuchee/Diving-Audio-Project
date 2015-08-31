using UnityEngine;
using System.Collections;

public class SwitchAmbientSounds : MonoBehaviour {
	GameObject player;
	public AudioClip[] ambientSounds = new AudioClip[2];
	// Use this for initialization
	void Start () {
		player =  GameObject.Find("First Person Controller");

	}
	
	// Update is called once per frame
	void Update () {;
		if( GetComponent<AudioSource>().isPlaying == false) {
			GetComponent<AudioSource>().Play (0);
		}
		if (player.transform.localPosition.y >= 7) {
			GetComponent<AudioSource>().clip = ambientSounds[0];

		}
		else {
			GetComponent<AudioSource>().clip = ambientSounds[1];
		}
	}
}
