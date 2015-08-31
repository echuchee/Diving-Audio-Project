using UnityEngine;
using System.Collections;

public class Sonification : MonoBehaviour {
	CharacterController player;
	private float o2level = 100;
	int pulse = 80;
	float pulseDec = 80.0f;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("First Person Controller").GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		//speed = player.velocity

		if(this.gameObject.name == "oxygenSource") {  //oxygen sonification
			float pY = player.transform.localPosition.y;
			if ((7.6f - pY) > 0 && o2level > 0) {
					o2level -= .02f;
			}
			else if (7.6f -pY <= 0) {
				o2level = 100;
			}
			if ((o2level <= 80 && o2level >= 79.98) || (o2level <= 60 && o2level >= 59.98) 
			    || (o2level <= 40 && o2level >= 39.98) || (o2level <= 20 && o2level >= 19.98)) { // plays sound every 20% o2 depleted
				float tempNum = o2level/100;
				float reverseO2 = 1- tempNum;
				GetComponent<AudioSource>().volume = reverseO2 * .8f;
				GetComponent<AudioSource>().pitch = .7f+(reverseO2 *.6f);
				GetComponent<AudioSource>().Play();
			}


			//play a sound every 20% of the tank being depleted. increased pitch based on depletion
		}
		if(this.gameObject.name == "speedSource") {  //surface speed sonification
			
			//when you surface to fast it will play the sound, louder sound if it exceeds the speed 6+
			if (Mathf.Abs(player.velocity.y) >= 6 && player.transform.localPosition.y <= 7.6) {
				float tempNum = (Mathf.Abs(player.velocity.y) - 6)/6;
				GetComponent<AudioSource>().volume = tempNum/4f;
				if (GetComponent<AudioSource>().isPlaying == false) {
					GetComponent<AudioSource>().Play();
				}
			}
		}
		if(this.gameObject.name == "pulseSource") {  //pulse sonification
			if (Input.GetButton ("Jump") || Input.GetKey(KeyCode.LeftShift) || Input.GetAxis ("Horizontal") > 0 || Input.GetAxis("Vertical") > 0 && pulse <= 140) {
				if (pulse <= 139) {
					pulseDec += .1f;
					pulse = (int) pulseDec;
				}
			}
			else if (pulse > 80) {
				pulseDec -= .1f;
				pulse = (int) pulseDec;
			}

			float tempNum2 = pulse/140.0f;
			float tempNum3 =.1f + (pulse-80.0f)/140.0f;
			GetComponent<AudioSource>().volume = .7f * tempNum3;
			GetComponent<AudioSource>().pitch = .2f + tempNum2 * 1.1f;  //.428  -> 0 80 - > 140
			//print (audio.pitch);
			if (GetComponent<AudioSource>().isPlaying == false) {
				GetComponent<AudioSource>().Play();
			}
			//more swimming, higher heartrate, faster pitched pulse
		}
		if(this.gameObject.name == "pressureSource") {  //pressure sonification
			//increase volume and pitch when past 30 and lower to surface
			float pY = Mathf.Abs (player.transform.localPosition.y - 7.74f);
			float tempNum = (48f-pY)/48f;
			float inverseNum = 1 - tempNum;
			if (pY >= 30) {
				GetComponent<AudioSource>().volume = .05f +  inverseNum/3;
				GetComponent<AudioSource>().pitch = .8f + inverseNum/2;
				if (GetComponent<AudioSource>().isPlaying == false) {
					GetComponent<AudioSource>().Play();
				}
			}
			else {
				GetComponent<AudioSource>().Stop ();
			}
			
		}
	}
}
