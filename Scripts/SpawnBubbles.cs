using UnityEngine;
using System.Collections;

public class SpawnBubbles : MonoBehaviour {
	public GameObject bubble;
	private int count = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		count++;
		if ((this.transform.localPosition.y <= 7) && (count % 60 == 0) ) {
			createBubbles(this.transform.localPosition);
		}
	}
	void createBubbles(Vector3 location) {
		Instantiate (bubble, new Vector3 (location.x, location.y + 2, location.z), Quaternion.identity);
	}	
}
