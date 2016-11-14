using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour {

	public int BaseHeight = 30;
	public GameObject[] BoardBases;
	private GameObject[] BaseList;
	public int[] bases;
	public bool[] directions;
	public float baseSize = 1.0f;
	public float posMult = 10.0f;
	private float oldX;
	private float oldY;
	private float oldZ;
	private float heightBase; 
	private float mroot2 = 5*Mathf.Sqrt (2);


	// Use this for initialization
	void Start () {
		heightBase = (baseSize/2) * posMult / Mathf.Sqrt (2);
		print (heightBase);
		initiateBoard ();
	}

	void initializeBase(){

		BaseList = new GameObject[BaseHeight];

		bases = new int[BaseHeight];
		directions = new bool[BaseHeight];
		for (int i = 0; i < BaseHeight; i++) {
			bases [i] = 0;// 0 -- nothing, 1-- Base, 2-- Vertical , 3-- Horizontal
		}
	}
	void initiateBoard(){		
		initializeBase();
		for (int i = 0; i < BaseHeight; i++) {
			if (i == 0) {
			
				BaseList[i] = GameObject.Instantiate (BoardBases [0]);
				BaseList [i].transform.position = new Vector3 (0, 0, 0);
				bases [i] = 1;
				oldX = 0;
				oldY = 0;
				oldZ = 0;
				directions [0] = false;
			} 
			else
			{
				

				int rv = Random.Range (0, 10);

				if (i == 1 || ((rv >= 1 && rv <=5) && (bases [i - 1] == 1 || bases [i - 1] == 2))) {
					bases [i] = 2;
					directions [i] = false;
					BaseList[i] = GameObject.Instantiate (BoardBases [1]);

					if (bases [i - 1] == 1) {
						
						// [i].gameObject.transform.Translate (new Vector3 (oldX + 5.0f + heightBase, oldY + (heightBase), oldZ));///
						BaseList [i].transform.position= new Vector3(oldX + 5.0f + heightBase-mroot2, oldY - heightBase,oldZ);


					} else {
						//BaseList [i].gameObject.transform.Translate (new Vector3 (oldX + heightBase*2 , oldY - heightBase*2 , oldZ));
						BaseList [i].transform.position= new Vector3(oldX + heightBase*2, oldY - heightBase*2,oldZ);

					}


				} else if ((rv >= 6 && rv <= 10) && (bases [i - 1] == 1 || bases [i - 1] == 3)) {
					bases [i] = 3;
					directions [i] = true;
					BaseList[i] = GameObject.Instantiate (BoardBases [2]);
				

					if (bases [i - 1] == 1) {
						BaseList [i].transform.position= new Vector3(oldX, oldY - heightBase,oldZ + 5 + heightBase-mroot2);
		
					}
					else {
						//BaseList [i].gameObject.transform.Translate (new Vector3 (oldX ,oldY + heightBase*2 , oldZ + heightBase*2 ));
						BaseList [i].transform.position= new Vector3(oldX, oldY - heightBase*2,oldZ + heightBase*2);
					
					}


				} else {
					bases [i] = 1;
					directions [i] = directions [i - 1];
					if (bases [i - 1] == 1)
						directions [i] = false;
					BaseList[i] = GameObject.Instantiate (BoardBases [0]);

					if (bases [i - 1] == 2) {
						//BaseList [i].gameObject.transform.Translate (new Vector3 (oldX + 10, oldY - heightBase, oldZ));
						BaseList [i].transform.position= new Vector3(oldX + 5 + heightBase+mroot2, oldY - heightBase,oldZ);

					} else if (bases [i - 1] == 3) {
						
						//BaseList [i].gameObject.transform.Translate (new Vector3 (oldX, oldY - heightBase, oldZ + 10));
						BaseList [i].transform.position= new Vector3(oldX, oldY - heightBase,oldZ + 5 +heightBase+mroot2);
			

					} else {
						
						//BaseList [i].gameObject.transform.Translate (new Vector3 (oldX + 10, oldY, oldZ ));
						BaseList [i].transform.position= new Vector3(oldX + 10, oldY ,oldZ);
					
					
					}
				
					}

				oldX = BaseList [i].transform.position.x;

				oldY = BaseList [i].transform.position.y;
				oldZ = BaseList [i].transform.position.z;

				
				//print("x :" +oldX +" y :" + oldY + " z : "+oldZ );
			}
		}
	}
	public int[] returnBases(){
		int[] baseR = new int[BaseHeight];
		for (int i = 0; i < BaseHeight; i++) {
			baseR [i] = bases [i];
		}
		return baseR;
	}
	public void startBoard(){
		Start ();
	}
	// Update is called once per frame
	void Update () {
	
	}
}
