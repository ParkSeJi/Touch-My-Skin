using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControll : MonoBehaviour {

	public Player_State player;
	public Text StateLabel;

	void Update() //매 프레임 마다 플레이어의 상태를 text로 출력
	{
		StateLabel.text = "Player state: " + player.PS;
	}
}
