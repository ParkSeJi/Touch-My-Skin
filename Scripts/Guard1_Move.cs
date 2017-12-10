using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard1_Move : MonoBehaviour {
	public float moveSpeed;	//움직이는 속도
	public GameObject pointA;	//목표지점 A
	public GameObject pointB;	//목표지점 B
	public bool reverseMove = false;	//거꾸로 돌아가는 지(y축 방향전환)
	public Transform objectToUse;	//game object-> 여기서는 캐릭터

	private float startTime;	//pointA, pointB에서 부터 시작하는 시간
	private float distanceATOB;	//pointA, pointB 사이의 거리
	private float distCovered;	//속력
	private float distPerTime;	//속력 / 거리

	void Start()
	{
		startTime = Time.time;	//start time
		transform.LookAt (pointA.transform);	//Point A 를 바라봄

		distanceATOB = Vector3.Distance(pointA.transform.position, pointB.transform.position);	//distance from A to B
	}
	void Update()
	{
		distCovered = (Time.time - startTime) * moveSpeed;
		distPerTime = distCovered / distanceATOB;
		if (reverseMove)
		{
			objectToUse.position = Vector3.Lerp(pointB.transform.position, pointA.transform.position, distPerTime);	//B -> A
		}
		else
		{
			objectToUse.position = Vector3.Lerp(pointA.transform.position, pointB.transform.position, distPerTime);	//A -> B
		}

		if ((Vector3.Distance(objectToUse.position, pointB.transform.position) == 0.0f 
			|| Vector3.Distance(objectToUse.position, pointA.transform.position) == 0.0f))	//PointA 또는 PointB와 캐릭터 사의 거리가 0.0f일때
		{
			if (reverseMove)
			{
				transform.LookAt (pointB.transform);	//Point B를 바라봄
				reverseMove = false;
			}
			else
			{
				transform.LookAt (pointA.transform);	//Point A 를 바라봄
				reverseMove = true;
			}
			startTime = Time.time;
		}
	}

	public float getMoveSpeed(){
		return moveSpeed;
	}

}
