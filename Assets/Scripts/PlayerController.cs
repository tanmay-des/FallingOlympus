using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public Rigidbody rb;
	public int direction = 0;

	// Use this for initialization
	void Start () {
		direction = 0;
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		rb.velocity =  new Vector3(10, 0, 0);

	}
}
