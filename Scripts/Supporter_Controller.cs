using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Supporter_Controller : MonoBehaviour {

	Player_State ps;

	// Use this for initialization
	void Start () {
		
		ps = GameObject.Find ("Player").GetComponent<Player_State> ();
	}

	// Update is called once per frame
	void Update () {

	}
	void OnTriggerEnter(){ 
		PlayerState state = ps.getState ();
		if (state.Equals (PlayerState.normal)) {
			Debug.Log ("Support : Hint");
		} else {
			Debug.Log ("Support : ...");
		}
	}
}
