using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour {
	public PlayerState ps = PlayerState.normal;
	public int mon_state;

	// Use this for initialization
	void Start () {
		mon_state = -1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){	//player detection.
		Debug.Log ("detection : " + other.gameObject);
		this.transform.LookAt (other.transform);	//player를 향해 고개를 돌림.
		//-> gameover() 이런식이 될듯.
		ps = other.gameObject.GetComponent<Player_State>().getState();

		if (ps.Equals(PlayerState.normal)) {
			mon_state = 0;
			Debug.Log ("GAME OVER");
		} else {
			Debug.Log (ps);
		}

	}

	public int getMonState(){
		return mon_state;
	}

}
