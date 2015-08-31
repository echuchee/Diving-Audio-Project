using UnityEngine;
using System.Collections;

public class DelayCaptainSound : MonoBehaviour {
	private int count = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		count++;
		if (count == 60) {
			GetComponent<AudioSource>().Play ();
		}
	}
}
