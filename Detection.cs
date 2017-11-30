using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){	//player detection.
		Debug.Log ("detection : " + other.gameObject);
		this.transform.LookAt (other.transform);	//player를 향해 고개를 돌림.
		//if(other.gameObject.state == normal) -> gameover() 이런식이 될듯.


	}

}
