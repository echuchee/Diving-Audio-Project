using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class UpdateUI : MonoBehaviour {
	CharacterController player;
	Text theText;
	float o2level = 100;
	int pulse = 80;
	float pulseDec = 80.0f;
	//public GameObject UI;
	// Use this for initialization
	void Start () {
		player = GameObject.Find("First Person Controller").GetComponent<CharacterController>();
		theText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		String updateMe = "";
		float pY = player.transform.localPosition.y;
		//calculate pulse
		//Input.GetButton ("Jump")\
		//Input.GetKey(KeyCode.LeftShift)
		//moveDirection = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
		//float decimalPulse = 80.0f;
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

		if((7.6f -pY) > 0 && o2level > 0.02) {
			o2level -= .02f;

		}
		else if (7.6f -pY <= 0) {		
			o2level = 100;

		}
		int tempDepth = (int)Mathf.Round(7.6f-pY);
		int tempSpeed = Mathf.Abs((int)player.velocity.y);
		String speedNum = tempSpeed.ToString();
		String o2Num = o2level.ToString("F2");
		if (tempDepth <= 0) {
			tempDepth = 0;
		}
		String depthNum = tempDepth.ToString();
		updateMe = "Depth : " + depthNum + " ft" + Environment.NewLine + "Oxygen Level : " + o2Num + "%" + Environment.NewLine + "Vertical Speed : "+ speedNum + " ft/s" + Environment.NewLine + "Pulse : " + pulse + " bpm";

		theText.text = updateMe;;
	}
}
