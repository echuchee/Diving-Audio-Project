using UnityEngine;
using System.Collections;

public class SelectConversation : MonoBehaviour {
	public AudioClip[] convos = new AudioClip[4];
	int conv = 0;
	int count = 0;
	int startcount = 0;
	// Use this for initialization
	void Start () {
		conv = Random.Range(0,4);
		this.GetComponent<AudioSource>().clip = convos[conv];
		//print ("conv : " + conv);
		//audio.Play (0);
	}
	
	// Update is called once per frame
	void Update () {
		startcount++;
		if (startcount >= 480) {
			if (GetComponent<AudioSource>().isPlaying == false) { //&& count == 120
				conv = Random.Range(0,4);
				this.GetComponent<AudioSource>().clip = convos[conv];
				count = 0;
				GetComponent<AudioSource>().Play (0);
			}	
			else if (GetComponent<AudioSource>().isPlaying == false) {
				count++;
			}
		}
	}
}
