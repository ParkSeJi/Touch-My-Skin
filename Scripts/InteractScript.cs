using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractScript : MonoBehaviour {


    public float interactDistance = 5f; // 문과의 상호작용 간격(거리)

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) //left마우스버튼을 클릭했을 때 
        {
            Debug.Log("first if");
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;  //앞의 정보를 얻기 위해 Raycasthit사용
            Debug.Log("Ray");
            if (Physics.Raycast(ray,out hit,interactDistance))
            {
                Debug.Log("Second if");
                if (hit.collider.CompareTag("Door")) // 태그에 부딪혔을 때
                {
                    hit.collider.transform.parent.GetComponent<DoorScript>().ChangeDoorState(); //부딪힌 대상의 부모 컴포넌트 취득하여 함수활용
                    Debug.Log("third if");
                }
            }
        }
    }
}
