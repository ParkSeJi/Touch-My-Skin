using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss_Trigger : MonoBehaviour {

	public GameObject canvas_talk;
	public GameObject canvas_main;
	public GameObject talkObject;
	private DialogueManager dialog;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		

	}

	void OnTriggerEnter(Collider other){
		dialog = talkObject.GetComponent<DialogueManager> ();
		if (other.tag == "Player") {
			Debug.Log ("boss_trigger : enter");
			other.GetComponent<PlayerMoveController> ().setMoveSpeed (0.0f);
			canvas_main.SetActive (false);
			canvas_talk.SetActive (true);
			dialog.StartDialogue ();
		}
	}

	void OnTriggerStay(Collider other){
		if (other.tag == "Player" && dialog.isEnd) {
			Debug.Log ("boss_trigge : stay");
			other.GetComponent<PlayerMoveController> ().setMoveSpeed (4.0f);
			canvas_main.SetActive (true);
			canvas_talk.SetActive (false);
		}
	}

}
