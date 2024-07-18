using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spinslow : MonoBehaviour
{
  public float rotateSpeed;

    void Update()
    {   // 회전
        // 기본적으로 transform 은 변수가 있다.
        // 세로축(y축)을 기준으로 빙빙 돌게 하고 싶다.
        
        // rotateSpeed = 20; // 알맞은 값을 알아내면 변수에 적용시켜 값을 고정한다.
        // update 에서는 컴퓨터의 사양이 다른 것을 고려하여 Time.deltaTime 을 곱해야한다.
        rotateSpeed = 15;
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime , Space.World);
        // transform.Rotate(new Vector3(0,0,-1) * rotateSpeed * Time.deltaTime , Space.World);
        
    }
}
