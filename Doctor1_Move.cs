using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doctor1_Move : MonoBehaviour {


	public float moveSpeed;	//움직이는 속도
	public GameObject[] pointArr;	//목표지점 arr
	public Transform objectToUse;	//game object-> 여기서는 캐릭터
	public float[] distance;	//pointA, pointB 사이의 거리

	private bool reverseMove;
	private float startTime;	//pointA, pointB에서 부터 시작하는 시간
	private float distCovered;	//속력
	private float distPerTime;	//속력 / 거리
	private int idx;

	void Start()
	{
		idx = 0;

		startTime = Time.time;	//start time
		reverseMove = false;
		for (int i = 0; i < 4 - 1; i++) {
			distance [i] = Vector3.Distance (pointArr [i].transform.position, pointArr [i + 1].transform.position);
		}

	}
	void Update()
	{
		distCovered = (Time.time - startTime) * moveSpeed;

		if (!reverseMove) {
			distPerTime = distCovered / distance[idx];
			moveNextPoint (pointArr [idx], pointArr [getNextIdx (idx, reverseMove)]);
			if (idx == 2 && (Vector3.Distance (objectToUse.position, pointArr[3].transform.position) == 0.0f)) {
				reverseMove = true;
				idx++;
				startTime = Time.time;
			}else if((Vector3.Distance (objectToUse.position, pointArr [getNextIdx (idx, reverseMove)].transform.position) == 0.0f)) {
				idx = getNextIdx (idx, reverseMove);
				startTime = Time.time;
				Debug.Log ("Idx : " + idx);
			}
			transform.LookAt (pointArr [getNextIdx (idx, reverseMove)].transform);

		} else {
			distPerTime = distCovered / distance[idx-1];
			moveNextPoint (pointArr [idx], pointArr [getNextIdx (idx, reverseMove)]);

			if (idx == 1 && (Vector3.Distance (objectToUse.position, pointArr [0].transform.position) == 0.0f)) {
				reverseMove = false;
				idx--;
				startTime = Time.time;

			} else if ((Vector3.Distance (objectToUse.position, pointArr [getNextIdx (idx, reverseMove)].transform.position) == 0.0f)) {
				idx = getNextIdx (idx, reverseMove);
				startTime = Time.time;
				Debug.Log ("rIdx : " + idx);
			}
			transform.LookAt (pointArr [getNextIdx (idx, reverseMove)].transform);

		}
		//
	}

	void moveNextPoint(GameObject a, GameObject b){
		objectToUse.position = Vector3.Lerp (a.transform.position, b.transform.position, distPerTime);

	}
	int getNextIdx(int i, bool reverse){
		if (!reverse)
			return i + 1;
		else
			return i - 1;
	}

	public float getMoveSpeed(){
		return moveSpeed;
	}
	public void setMoveSpeed(float spd){
		moveSpeed = spd;
	}
}
