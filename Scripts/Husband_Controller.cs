using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Husband_Controller : MonoBehaviour {
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
	void OnTriggerEnter(){ 
		if (ps.getState ().Equals (PlayerState.death) || ps.getState ().Equals (PlayerState.safety)) return;
		transform.rotation = Quaternion.LookRotation (new Vector3 (player.position.x, this.transform.position.y, player.position.z) - transform.position);
		PlayerState state = ps.getState ();

		animator.SetBool ("talk", true);
		if (state.Equals (PlayerState.normal) || state.Equals (PlayerState.supporter)) {
			ps.setState (PlayerState.death);
			Debug.Log ("Husband : GameOver");
		} else if (state.Equals (PlayerState.wife)) {
			Debug.Log ("Husband : Hint");
		} else {
			Debug.Log ("Husband : 돌아가");
		}
	}

	void OnTriggerExit(){

		animator.SetBool ("talk", false);
	}
}
