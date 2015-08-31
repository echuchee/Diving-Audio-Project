using UnityEngine;
using System.Collections;

public class bubbleMovement : MonoBehaviour {
	public GameObject bubble;
	private float originalY;

	// Use this for initialization
	void Start () {
		originalY = bubble.transform.localPosition.y;
	}
	
	// Update is called once per frame
	void Update () {
		bubble.transform.localPosition = new Vector3 (bubble.transform.localPosition.x, bubble.transform.localPosition.y+.01f, bubble.transform.localPosition.z);
		if ((this.transform.localPosition.y >= originalY +12.0f) || (this.transform.localPosition.y >= 8.075)) {  // bubbles last 20 seconds in height
			Destroy(bubble, 0.0f);
		}
	}
}
