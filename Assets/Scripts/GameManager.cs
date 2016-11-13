using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject player;
	public GameObject board ;
	// Use this for initialization
	void Awake() {
		
		GameObject.Instantiate (player);
		GameObject.Instantiate (board);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
