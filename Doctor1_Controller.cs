using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doctor1_Controller : MonoBehaviour {

	CharacterController controller;
	Animator animator;
	Vector3 direction = Vector3.zero;
	public float gravity;
	public float moveSpeed;

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController> ();
		animator = GetComponent<Animator> ();
		moveSpeed = GetComponent<Doctor1_Move> ().getMoveSpeed ();

	}

	// Update is called once per frame
	void Update () {

		direction.y -= gravity * Time.deltaTime;
		controller.Move (direction * Time.deltaTime);	
		animator.SetBool("Walk", moveSpeed > 0.0f);

		if (GetComponent<Detection> ().getMonState () == 0) {	//game over
			animator.SetTrigger ("SprintSlidle");
			GetComponent<Doctor1_Move> ().setMoveSpeed (0);
		}
	}
}