using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard1_Controller : MonoBehaviour {

	CharacterController controller;
	Animator animator;
	Vector3 direction = Vector3.zero;
	Player_State ps;
	Guard1_Move Move;
	public Transform player;
	public float gravity;
	public float moveSpeed;
	bool isMeet;
	bool keepWalk = true;
	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController> ();
		animator = GetComponent<Animator> ();
		Move = GetComponent<Guard1_Move> ();
		player = GameObject.Find ("Player").transform;
		ps = GameObject.Find ("Player").GetComponent<Player_State> ();
	
		isMeet = true;
	}

	// Update is called once per frame
	void Update () {
		direction.y -= gravity * Time.deltaTime;
	//	controller.Move (direction * Time.deltaTime);
		animator.SetBool ("walk", isMeet);
		if (keepWalk) {
			Move.walk ();
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			if (ps.getState ().Equals (PlayerState.death) || ps.getState ().Equals (PlayerState.safety)) return;
			transform.rotation = Quaternion.LookRotation (new Vector3 (player.position.x, this.transform.position.y, player.position.z) - transform.position);
			PlayerState state = ps.getState ();

			//animator.SetBool ("walk", false);
			keepWalk = false;
			isMeet = false;
			if (state.Equals (PlayerState.normal) || state.Equals (PlayerState.supporter)) {
				ps.setState (PlayerState.death);
				Debug.Log ("Husband : GameOver");
			} else {
				Debug.Log ("Husband : Hello!!");
			}
		}
	}
	void OnTriggerExit(Collider other){
		//animator.SetBool ("walk", true);
		if (other.tag == "Player") {
			keepWalk = true;
			isMeet = true;
		}
	}



}
