using UnityEngine;
using System.Collections;

public class Boat2Movement : MonoBehaviour {
	private int state = 0;// 0 -> first straight, 1-> turn, 2-> 2nd straight, 3- > 2nd turn
	private Quaternion rotation;
	private float currentRotation = 0.0f;
	public float boatspeed = 10f;
	public int turnSpeed = 30;
	private bool stopped = false;
	void Start () {
	
	}
	void OnCollisionEnter (Collision col) {
		stopped = true;
	}
	void OnCollisionExit () {
		stopped = false;
	}
	// Update is called once per frame
	void Update () {

		float thisX = this.transform.localPosition.x;
		float thisY = this.transform.localPosition.y;
		float thisZ = this.transform.localPosition.z;
	
		if (stopped == false) {
			if(thisX <= -130 && state !=2)  {
				state = 1;
			}
			if (thisX > 40 && state != 0) {
				state = 3;
			}
			if (state == 0) {
				this.transform.localPosition = new Vector3(thisX -boatspeed, thisY, thisZ);
			}
			else if (state == 1) {
				currentRotation -= Time.deltaTime*turnSpeed;
				rotation.eulerAngles = new Vector3(0, currentRotation, 0);
				transform.localRotation = rotation;
				if (transform.localRotation.y <= -.999) {
					state = 2 ;
				}
			}
			else if (state == 2) {
				this.transform.localPosition = new Vector3(thisX +boatspeed, thisY, thisZ);
			}

			else if (state == 3) {
				currentRotation += Time.deltaTime*turnSpeed;
				rotation.eulerAngles = new Vector3(0, currentRotation, 0);
				transform.localRotation = rotation;
				if (Mathf.Abs(transform.localRotation.y) <= .02) {
					state = 0 ;
				}
			}
		}

	}
}

