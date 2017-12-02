using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState{
	normal,          //주인공
	patient,		 //환자 (조력자) 
	Death,           //주인공_사망
	higeLevel_re,    //wife 연구원
	lowLevel_re,     //말단연구원
	safety           //안전구역
}
	
public class Player_State : MonoBehaviour {

	public PlayerState PS; // 상태이용하기

	public AudioClip[] Sound; //오디오 관리
	public int count;

	void Start()
	{
		PS = PlayerState.normal; //초기화
	}

	void Update()
	{
		if (PS == PlayerState.Death)
			GameOver ();
	}

	void GameOver()
	{
		//Death_Scene move
	}
		

	void SoundPlay(int num) //사운드
	{
		//audio.clip = Sound[num];
		//audio.Play ();
	}

	public void OnClickSkill_Btn1() // 스킬 버튼
	{
		PS = PlayerState.lowLevel_re;
		Debug.Log ("Skill 1 use");

	}

	public void OnClickSkill_Btn2()
	{
		PS = PlayerState.patient;
		Debug.Log ("Skill 2 use");
	}

	public void OnClickSkill_Btn3()
	{
		PS = PlayerState.higeLevel_re;
		Debug.Log ("Skill 3 use");
	}
}
