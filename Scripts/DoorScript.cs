using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour {

    public bool open; //열렸는지 안 열렸는지
    public float doorOpenAngle  = 170f; //열린 문의 각도
    public float doorCloseAngle = 0f;   //닫힌 문의 각도
    public float smooth = 2f;

    public void ChangeDoorState() //문의 상태 변경
    {
        open = !open;
        Debug.Log("open=!open");
    }

    void Update()
    {
        if(open)  // open == true 
        {
            Quaternion targetRotation = Quaternion.Euler(0,doorOpenAngle,0); //문의 y축 회전을 열린 문의 각도로 한다.
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smooth * Time.deltaTime);
        }
        else
        {
            Quaternion targetRotation2 = Quaternion.Euler(0, doorCloseAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation2, smooth * Time.deltaTime);
        }
    }
}
