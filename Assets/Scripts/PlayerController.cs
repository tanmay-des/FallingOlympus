using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public Rigidbody rb;
	public int direction = 0;
	public float maxSpeed = 5;
	public int[] blist ;
	public GameObject bm;
	public BoardManager brm;
	private int CurrentBase = 0; 
	private float oldX = 0;
	private float oldY = 0;

	// Use this for initialization
	void Start () {
		direction = 0;
		bm = GameObject.FindGameObjectWithTag("Board");
		brm = bm.GetComponent<BoardManager> ();
		rb = GetComponent<Rigidbody> ();
		blist = brm.bases;
		Physics.gravity = new Vector3 (0, -20.0f, 0);
		initiateList ();
	}

	void initiateList(){
		blist = brm.returnBases ();
	}


	void Update() {
		rb.AddForce (0, -10, 0, ForceMode.Impulse);

		if (rb.transform.position.x >= oldX && rb.transform.position.y <= oldY) {
			rb.AddForce (0, 9, 0,ForceMode.Impulse);
		}

		oldX = rb.transform.position.x;
		oldY = rb.transform.position.y;

		checkNextBase ();
	}

	void setSpeed(){
		CurrentBase += 1;
		if (blist [CurrentBase] == 2) {
			rb.velocity = new Vector3 (10, -10,0);
		} else if (blist [CurrentBase] == 3) {
			rb.velocity = new Vector3 (0, -10, 10);
		}
	}

	void checkNextBase(){
		if (blist[CurrentBase] == 1) {
			if (rb.transform.position.x >= 5) {
				setSpeed ();
			} 	 	
			else	rb.velocity = new Vector3 (10, 0,0);
		}
	}



}
