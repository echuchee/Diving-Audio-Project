using UnityEngine;
using System.Collections;

public class CustomCharController : MonoBehaviour {
	public float gravity = 2.0f;
	public float moveSpeed = 10.0f;
	//public float maxSpeed = 50.0f;
	public float maxAccel = 20.0f;
	public float regAccel = 5.0f;
	private Vector3 moveDirection = Vector3.zero;
	private bool grounded = false;
	private float startTime = 0;
	private bool underwater = false;
	private float initialTime = 0, initialTime2 = 0;
	public AudioClip[] breathingSounds = new AudioClip[3];
	public AudioClip splashSound;
	public AudioClip surfaceSound;
	public bool enableBreathing = false;
	public float breathingVol;
	private int breathCount = 0;
	private bool onBoat = true;
	private int surfaceCount = 0;

	public CharacterController tempController;
	private Vector3 decayMovement;



	//AudioReverbZone rz = GetComponent<AudioReverbZone>(this.gameObject);
	AudioReverbZone test;


	private bool ladderarea = false; // Ladderarea boolean used to determine whether player is next to it so they can climb back on to boat.

	void OnCollisionEnter (Collision col)
	{
		//print (col.gameObject.name);
		if(col.gameObject.name == "Main Boat" && GetComponent<AudioSource>().isPlaying == false && underwater == false) { // move to feet
			//audio.Play(0);
		}
		if (col.gameObject.name == "splashzone") {
			//print ("yes");
		}

	}
	// Use this for initialization
	void Start () {
		test = GetComponent("AudioReverbZone") as AudioReverbZone;
		tempController = GetComponent<CharacterController>();
		decayMovement = new Vector3 (0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (enableBreathing == true) {
			if ( this.transform.localPosition.y < 7.6) {
				if (GetComponent<AudioSource>().isPlaying == false)  {
					GetComponent<AudioSource>().volume = breathingVol;
					breathCount++;
					if (breathCount == 3) {
						breathCount = 0;
					}
					GetComponent<AudioSource>().clip = breathingSounds[breathCount];
					GetComponent<AudioSource>().Play(0);
				}

			}
		}
		grounded = false;
		CharacterController controller = GetComponent<CharacterController>();
		moveDirection = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
		moveDirection = transform.TransformDirection (moveDirection);
		moveDirection *= moveSpeed;
		if (this.transform.localPosition.y >= 10.36) {
			onBoat = true;
		}
		else if (this.transform.localPosition.y <= 9) {
			if (onBoat == true) {
				GetComponent<AudioSource>().volume = .5f;
				GetComponent<AudioSource>().PlayOneShot(splashSound);
			}
			onBoat = false;
		}
		if (this.transform.localPosition.x <= -6.2 && this.transform.localPosition.x >= -7.5 && 
		    this.transform.localPosition.y >= 7.5 && this.transform.localPosition.y <= 10.8 && this.transform.localPosition.z <= 2 
		    && this.transform.localPosition.z >= -1) {
			ladderarea = true;

		}
		else {
			ladderarea = false;
		}
		//print ("Loc : " + this.transform.localPosition + " . t/f? : " +ladderarea);
		if (this.transform.localPosition.y <= 7.6) {
			underwater = true;
			test.enabled = true;

		}
		else {
			underwater = false;
			test.enabled = false;
		}
		if (Input.GetButton ("Jump") && (underwater == true || ladderarea == true)) { 
			startTime = Time.time;
			grounded = false;
			if (initialTime == 0) {
				initialTime = Time.time;
			}
			if (regAccel * (Time.time -initialTime) <= maxAccel) {
				moveDirection.y += regAccel * (Time.time -initialTime);

				//print (tempController.velocity.y);
			}
			else if (regAccel * (Time.time -initialTime) >= maxAccel) {
				moveDirection.y += maxAccel;

			}
			decayMovement = tempController.velocity;

		}
		surfaceCount++;
		if (Input.GetKey(KeyCode.Q)) {
			//
			if (surfaceCount >= 140) {
				GetComponent<AudioSource>().volume = .075f;
				GetComponent<AudioSource>().bypassReverbZones = true;
				GetComponent<AudioSource>().PlayOneShot(surfaceSound);
				GetComponent<AudioSource>().bypassReverbZones = false;
				surfaceCount = 0;
			}
		}
		if (Input.GetButton("Jump") == false) {
			initialTime = 0;
		}	
		if (Input.GetKey(KeyCode.LeftShift)) {
			if (initialTime2 == 0) {
				initialTime2 = Time.time;
			}
			if (regAccel * (Time.time -initialTime2) <= maxAccel) {
				moveDirection.y -= regAccel * (Time.time-initialTime2);
			}
			else if (regAccel * (Time.time -initialTime2) >= maxAccel) {
				moveDirection.y -= maxAccel;
			}
			decayMovement = tempController.velocity;
		}



		if (Input.GetKey(KeyCode.LeftShift) == false) {
			initialTime2 = 0;
		}
		if (grounded == false) {  // above water gravity
			if(this.transform.localPosition.y >= 8) {
				moveDirection.y -= gravity *(Time.time-startTime);
			}
		}

		if (controller.velocity.y == 0) {
			grounded = true;
		}
		if (grounded == true) {
			startTime = Time.time;
			moveDirection.y -= gravity *(Time.time-startTime);
		}
		if(Input.GetKey(KeyCode.LeftShift) == false && Input.GetButton ("Jump") == false && underwater == true) {
			moveDirection = new Vector3(moveDirection.x, decayMovement.y,moveDirection.z);

			decayMovement = decayMovement * .9975f;
			
		}

		controller.Move(moveDirection * Time.deltaTime);



	}
	//void OnControllerColliderHit(ControllerColliderHit hit)
	//{
		//grounded = false;
	//}
	
}
