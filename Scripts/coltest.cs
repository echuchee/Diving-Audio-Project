using UnityEngine;
using System.Collections;

public class coltest : MonoBehaviour {
	private int stepCount = 0;
	CharacterController player;
	void Start () {
		player = GameObject.Find("First Person Controller").GetComponent<CharacterController>();
	}
	void Update () {

		// Detects walking on the deck

		GameObject player = GameObject.Find ("First Person Controller");
		CharacterController temp = player.GetComponent<CharacterController> ();

		if (temp.velocity != new Vector3(0,0,0)) {	
			stepCount++;
			if(player.transform.localPosition.y >= 10.54 && stepCount >= 30) {
				GetComponent<AudioSource>().Play (0);
				stepCount = 0;
			}
		}
	}
}
