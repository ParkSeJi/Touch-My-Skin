using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

//출처 : https://www.youtube.com/watch?v=_nRzoTzeyxU&t=435s
public class DialogueManager : MonoBehaviour {

	public Text nameText; //text에 npc 이름
	public Text dialogueText; // text에 대화문 구성

	public GameObject trigger;
	public GameObject canvers;
	public Animator animator;
	public bool isEnd = false;
	public bool clear;
	private Dialogue dialogue; //대화 불러오기
    //public Queue<string> sentences; //대화문을 큐를 이용하여 활용함.
	public Queue<KeyValuePair<string, string> > sentences;

	// Use this for initialization
	void Start () //초기화
	{
		sentences = new Queue<KeyValuePair<string, string> >();
		//textValue = System.IO.File.ReadAllLines (path); // 전체 텍스트읽기
		//dialogue = trigger.GetComponent<Dialogue>();
	}

	public void StartDialogue(Dialogue dial)
    {
		//animator.SetBool ("isOpen", true);
		isEnd = false;
		sentences.Clear ();
		dialogue = dial;
		for(int i=0; i<dialogue.names.Length; i++)
		{
			KeyValuePair<string, string> str = new KeyValuePair<string,string> (dialogue.names[i], dialogue.sentences[i]);

			//sentences.Enqueue (KeyValuePair<string, string>(dialogue.names[i], dialogue.sentences[i])); // 큐에 대화 문장들을 삽입.
			sentences.Enqueue (str);

		}

		DisplayNextSentence (); //next 버튼 
    }

	public void DisplayNextSentence()
	{
		if (sentences.Count == 0) 
		{
			isEnd = true;
			EndDialogue ();
			return;
		}
			
		KeyValuePair<string, string> sentence = sentences.Dequeue ();
		nameText.text = sentence.Key; // npc name출력
		StopAllCoroutines();
		StartCoroutine (TypeSentence (sentence));
	}


	IEnumerator TypeSentence (KeyValuePair<string, string> sentence)
	{
		dialogueText.text = "";
		foreach (char letter in sentence.Value.ToCharArray()) 
		{
			dialogueText.text += letter;
			yield return null;
		}
	}

	void EndDialogue()
	{
		animator.SetBool ("isOpen", false);
		Debug.Log ("End of conversation.");
	}
}
