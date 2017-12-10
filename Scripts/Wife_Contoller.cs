using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wife_Contoller : MonoBehaviour {
	Player_State ps;
	public Transform player;
	Animator animator;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		player = GameObject.Find ("Player").transform;
		ps = GameObject.Find ("Player").GetComponent<Player_State> ();
	}

	// Update is called once per frame
	void Update () {

	}
	void OnTriggerEnter(Collider other){ 
		if (other.tag == "Player") {
			animator.SetBool ("talk", true);
			if (ps.getState ().Equals (PlayerState.death) || ps.getState ().Equals (PlayerState.safety)) return;
			transform.rotation = Quaternion.LookRotation (new Vector3 (player.position.x, this.transform.position.y, player.position.z) - transform.position);
			PlayerState state = ps.getState ();
			if (state.Equals (PlayerState.normal)) {
				ps.setState (PlayerState.death);
				Debug.Log ("Wife : GameOver");
			} else if (state.Equals (PlayerState.supporter)) {
				Debug.Log ("Wife : Hint");
			} else {
				Debug.Log ("Wife : 돌아가");
			}
		}
	}

	void OnTriggerExit(Collider other){
		if (other.tag == "Player") animator.SetBool ("talk", false);
	}
}
