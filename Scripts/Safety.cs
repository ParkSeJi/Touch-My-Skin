using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Safety : MonoBehaviour {

	bool fallIn;
	public Player_State player;
	public string activeTag;

	public bool IsFallIn()
	{
		return fallIn;
	}

	void OnTriggerEnter (Collider other) //콜라이더에 들어가면 플레이어는 안전상태로 변환
	{
		if (other.gameObject.tag == "Player") 
		{
			fallIn = true;
			player.PS = PlayerState.safety;
		}
	}

	void OnTriggerExit (Collider other)
	{
		if (other.gameObject.tag == "Player") //콜라이더에서 나오면 플레이어는 normal상태로 변환
		{
			fallIn = false;
			player.PS = PlayerState.normal;
		}
	}
}
