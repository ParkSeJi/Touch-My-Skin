using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState{
	normal,
	End_researcher,  //말단 연구원
	patient,		 //환자
	Wife_researcher,  //수석연구원 아내
	Death
}
	
public class Player_State : MonoBehaviour {

	public PlayerState PS; // 상태이용하기

	public AudioClip[] Sound; //오디오 관리

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
		

	void SoundPlay(int num)
	{
		//audio.clip = Sound[num];
		//audio.Play ();
	}

	public void OnClickSkill_Btn1()
	{
		PS = PlayerState.End_researcher;
		Debug.Log ("Skill 1 use");
	}

	public void OnClickSkill_Btn2()
	{
		PS = PlayerState.patient;
		Debug.Log ("Skill 2 use");
	}

	public void OnClickSkill_Btn3()
	{
		PS = PlayerState.Wife_researcher;
		Debug.Log ("Skill 3 use");
	}
}
