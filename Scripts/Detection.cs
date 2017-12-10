using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//가만히 서있는 enemy를 위한 script (wife, support, husband
public class Detection : MonoBehaviour {
	Player_State ps;

	public float gravity;
	public float findRange ;
	public Transform player;

	// Use this for initialization
	void Start () {
		findRange = 3f;
		player = GameObject.Find ("Player").transform;
		ps = GameObject.Find ("Player").GetComponent<Player_State> ();
	}

	// Update is called once per frame
	void Update () {
		distanceCheck ();
	}
	void distanceCheck(){
	if(Vector3.Distance (player.position, transform.position) < findRange) {
			transform.rotation = Quaternion.LookRotation (new Vector3 (player.position.x, this.transform.position.y, player.position.z) - transform.position);
		}
	} 
}
