using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//출처 : https://www.youtube.com/watch?v=xcWIXRESo-8&t=865s
public class Interact : MonoBehaviour {

	public float interactDistance = 5f;
	public bool check =true;
	public GameObject light1;
	public GameObject light2;
	public GameObject light3;
	public GameObject light4;
	public GameObject light5;
	public GameObject light6;
	public GameObject light7;
	public GameObject[] item;
	public GameObject[] btn;
	//7,8,9,10.11,12,1
	void Update()
	{
		if (Input.GetKeyDown (KeyCode.Mouse1)) 
		{
			Ray ray = new Ray (transform.position, transform.forward);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit, interactDistance)) 
			{
				if (hit.collider.CompareTag ("Door")) {
					Door door = hit.collider.transform.parent.GetComponent<Door> ();
					if (door == null)
						return;
					door.ChangeDoorState ();
				} else if (hit.collider.CompareTag ("item1")) {
					//hit.collider.transform.parent.GetComponent<ItemScript>().GetItem_skill();
					btn[0].SetActive (true);
					Debug.Log ("getSkill");
					Destroy (item[0]);
				} else if (hit.collider.CompareTag ("item2")) {
					btn[1].SetActive (true);
					Debug.Log ("getSkill");
					Destroy (item[1]);
				} else if (hit.collider.CompareTag ("item3")) {
					btn[2].SetActive (true);
					Debug.Log ("getSkill");
					Destroy (item[2]);
				} else if (hit.collider.CompareTag ("Switch")) {
					if (check) {
					    light1.SetActive (false);
						light2.SetActive (false);
						light3.SetActive (false);
						light4.SetActive (false);
						light5.SetActive (false);
						light6.SetActive (false);
						light7.SetActive (false);
						check = false;
					} else if(!check){
						light1.SetActive (true);
						light2.SetActive (true);
						light3.SetActive (true);
						light4.SetActive (true);
						light5.SetActive (true);
						light6.SetActive (true);
						light7.SetActive (true);
						check = true;
					}

				}

			}
		}
	}
}

