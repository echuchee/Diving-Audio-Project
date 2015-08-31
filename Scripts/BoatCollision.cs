using UnityEngine;
using System.Collections;

public class BoatCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter (Collision col)
	{
		//print (col.gameObject.name);
		if(col.gameObject.name == "First Person Controller" && GetComponent<AudioSource>().isPlaying == false && GameObject.Find("First Person Controller").transform.localPosition.y < 9) { // move to feet
			GetComponent<AudioSource>().Play(0);
		}
		
	}
}
