using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Doctor1_Controller : MonoBehaviour {
	CharacterController controller;
	Animator animator;
	Vector3 direction = Vector3.zero;
	Doctor1_Move Move;
	Player_State ps;

	public float gravity;
	public float findRange ;
	public Transform player;

	bool keepWalk = true;
	// Use this for initialization
	void Start () {
		findRange = 3f;
		player = GameObject.Find ("Player").transform;
		ps = GameObject.Find ("Player").GetComponent<Player_State> ();
		controller = GetComponent<CharacterController> ();
		animator = GetComponent<Animator> ();
		Move = GetComponent<Doctor1_Move> ();
	}

	// Update is called once per frame
	void Update () {
		direction.y -= gravity * Time.deltaTime;
//		controller.Move (direction * Time.deltaTime);
		if (keepWalk) {
			animator.SetBool ("Walk", true);
			Move.walk ();
		}
	}
	/*
	void distanceCheck(){
		if(Vector3.Distance (player.position, transform.position) < findRange) {
			//바라보기.
			transform.rotation = Quaternion.LookRotation (new Vector3 (player.position.x, this.transform.position.y, player.position.z) - transform.position);

			//normal 이나 supporter 상태 일때.
			if (ps.getState ().Equals (PlayerState.normal) || ps.getState ().Equals (PlayerState.supporter)) {
				Debug.Log (ps + ": gameover : ");
				animator.SetBool ("Walk", false);
				ps.setState (PlayerState.death);	// gameover

			}
		}else {
			animator.SetBool ("Walk", true);
			Move.walk ();
		}
	}
	*/
	void OnTriggerEnter(Collider other){
		Debug.Log ("OnTriggerEnter");
		if (ps.getState ().Equals (PlayerState.death) || ps.getState ().Equals (PlayerState.safety))
			return;
		
		if (other.tag == "Player") {
			transform.rotation = Quaternion.LookRotation (new Vector3 (player.position.x, this.transform.position.y, player.position.z) - transform.position);
			keepWalk = false;
			animator.SetBool ("Walk", false);

			if (ps.getState ().Equals (PlayerState.normal) || ps.getState ().Equals (PlayerState.supporter)) {
				Debug.Log (ps.getState() + ": gameover : ");
				ps.setState (PlayerState.death);	// gameover

			} else {
				Debug.Log (ps.getState() + "어쩐일이세요 ?");
			}

		}
	}
	void OnTriggerExit(Collider other){
		Debug.Log ("OnTriggerExit");
		if (other.tag == "Player") {
			keepWalk = true;
		}
	}
}