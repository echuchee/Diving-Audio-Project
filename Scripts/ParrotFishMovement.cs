using UnityEngine;
using System.Collections;

public class ParrotFishMovement : MonoBehaviour {
	public float parrotFishSpeed = .01f;

	private int state = 0; // 0 -> eating from top, 1-> moving down, 2-> eating from bottom, 3-> moving up
	private float currY;
	private float tempTime;
	private float currTime;
	private float thisX, thisZ;
	public AudioClip audioFix;

	// -4.5 -> -8.2
	void Start () {
		//print (name + " : " + this.transform.localPosition.y);
		currY = this.transform.localPosition.y;
		if (currY >= -4.6) {
			state = 0;
			tempTime = Time.time;
		}
		else if(currY < 4.6 && currY > -8.2) {
			state = 1;
		}
		else if(currY <= -8.1) {
			state = 2;
			tempTime = Time.time;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<AudioSource>().isPlaying == false ) {
			GetComponent<AudioSource>().loop = true;
			GetComponent<AudioSource>().Play ();
		}
			currY = this.transform.localPosition.y;
			thisX = this.transform.localPosition.x;
			thisZ = this.transform.localPosition.z;
			currTime = Time.time - tempTime;
				if (currTime >= 2) {
						if (state == 0) {
								state = 1;
						} else if (state == 2) {
								state = 3;
						}
				}
				if (state == 1) {
						this.transform.localPosition = new Vector3(thisX, currY -parrotFishSpeed, thisZ);
						if (this.transform.localPosition.y <= -8.2) {
								tempTime = Time.time;
								state = 2;
						}
				} else if (state == 3) {
			this.transform.localPosition = new Vector3(thisX, currY +parrotFishSpeed, thisZ);
						if (this.transform.localPosition.y >= -4.5) {
								tempTime = Time.time;
								state = 0;
						}
				}
		}

}
