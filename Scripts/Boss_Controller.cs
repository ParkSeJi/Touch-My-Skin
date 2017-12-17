using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BossState{
	Idle, Move, Talk
}


public class Boss_Controller : MonoBehaviour {


	public BossState BS;
	public Animator animator;
	// Use this for initialization
	float Speed;
	public float MoveSpeed;
	public float FindRange = 20f;
	public Transform Player;

	void Start () {
		Player = GameObject.Find ("Player").transform;
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (BS == BossState.Idle) {
			DistanceCheck ();
		} else if (BS == BossState.Move) {
			MoveUpdate ();
			TalkRangeCheck ();
		} else if (BS == BossState.Talk) {
			TalkRangeCheck ();
		}
	}

	void DistanceCheck(){
		if (Vector3.Distance (Player.position, this.transform.position) >= FindRange) {	//player가 범위 밖 일때
			BS = BossState.Idle;
			animator.SetBool ("walk", false);
			Speed = 0;
		} else {
			BS = BossState.Move;
			animator.SetBool ("walk", true);
			Speed = MoveSpeed;
		}
	}

	void MoveUpdate(){
		transform.rotation = Quaternion.LookRotation (
			new Vector3 (Player.position.x, this.transform.position.y, Player.position.z)- transform.position);
		transform.Translate (Vector3.forward * Speed * Time.deltaTime);
	}

	void TalkRangeCheck(){
		if (Vector3.Distance (Player.position, this.transform.position) < 2f) {
			Speed = 0;
			BS = BossState.Talk;
		} else {
			Speed = MoveSpeed;
			BS = BossState.Move;
		}
	}

}
