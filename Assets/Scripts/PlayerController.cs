using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public Rigidbody rb;
	public int direction = 0;
	public float maxSpeed = 5;
	public int[] blist ;
	public bool[] dir;
	public GameObject bm;
	public BoardManager brm;
	private int CurrentBase = 0; 
	private float oldX = 0;
	private float oldY = 0;
	private float oldZ = 0;
	private float targetX = 0;
	private float targetZ = 0;

	// Use this for initialization
	void Start () {

		direction = 0;
		bm = GameObject.FindGameObjectWithTag("Board");
		brm = bm.GetComponent<BoardManager> ();
		rb = GetComponent<Rigidbody> ();
		blist = brm.bases;
		dir = brm.directions;
		Physics.gravity = new Vector3 (0, -20.0f, 0);
		initiateList ();
		targetX = 5.0f;
		targetZ = 5.0f;

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
		oldZ = rb.transform.position.z;

		checkBlock ();

		float maxVV = 30.0f;
		Vector3 xV = new Vector3 (maxVV, 0, 0);
		Vector3 zV = new Vector3 (0, 0, maxVV);
		Vector3 V2 = new Vector3 (maxVV / Mathf.Sqrt(2), -maxVV / Mathf.Sqrt(2), 0);
		Vector3 V3 = new Vector3 (0, -maxVV/ Mathf.Sqrt(2), maxVV / Mathf.Sqrt(2));


		if (blist [CurrentBase] == 1) {
			if (CurrentBase + 1 < blist.Length) {
				if (dir [CurrentBase] != dir [CurrentBase + 1]) {
					if (dir [CurrentBase]) {
						if (oldZ >= targetZ - 5.0f) {
							rb.velocity = xV;	
						} else {
							rb.velocity = zV;
						}
					} else {
						if (oldX >= targetX - 5.0f) {
							rb.velocity = zV;
						} else {
							rb.velocity = xV;
					    }
					}
				} else {
					if (dir [CurrentBase]) {
						rb.velocity = zV;
					} else {
						rb.velocity = xV;
					}
				}
			}
		} else if (blist [CurrentBase] == 2) {
			rb.velocity = V2;
		} else if (blist [CurrentBase] == 3) {
			rb.velocity = V3;
		}
	}

	void checkBlock(){
		if (targetX < oldX || targetZ < oldZ) {
			CurrentBase++; 
			if (CurrentBase >= blist.Length)
				return;

			if (blist [CurrentBase] == 1) {
				if (CurrentBase + 1 < blist.Length) {
					if (dir [CurrentBase]) {
						targetZ += 10.0f;
					} else {
						targetX += 10.0f;
					}
				}
			}else if(blist[CurrentBase] == 2){
				targetX += 10.0f / Mathf.Sqrt (2);
			}else {
				targetZ += 10.0f / Mathf.Sqrt (2);
			}
		}
	}



}
