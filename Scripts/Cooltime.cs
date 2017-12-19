using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//출처 : https://www.youtube.com/watch?v=8Xgao1qP7xw
public class Cooltime : MonoBehaviour {

	public Image img;
	public Button btn;
	public float cooltime;
	bool isCoolTime;

	void Start()
	{
		btn.GetComponent<Button> ();

		isCoolTime = false;
	}

	void Update()
	{
		CoolTimeImage ();
	}

	public void CoolTimeImage()
	{
		if (isCoolTime) 
		{
			btn.enabled = false;
			img.fillAmount += 1 / cooltime * Time.deltaTime;

			if (img.fillAmount >= 1) 
			{
				img.fillAmount = 0;
				isCoolTime = false;
				btn.enabled = true;
			}
		}
	}

	public void ButtonClick()
	{
		isCoolTime = true;
		CoolTimeImage ();
	}

}

