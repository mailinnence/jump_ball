using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item : MonoBehaviour
{
    // 회전값 변수 
    // 아직 얼마의 값이 적당한지 알 수 없다.
    // 이를 위해서는 시험용 값을 넣을 수 있는 변수를 사용한다.
    public float rotateSpeed;

    void Update()
    {   // 회전
        // 기본적으로 transform 은 변수가 있다.
        // 세로축(y축)을 기준으로 빙빙 돌게 하고 싶다.
        
        // rotateSpeed = 20; // 알맞은 값을 알아내면 변수에 적용시켜 값을 고정한다.
        // update 에서는 컴퓨터의 사양이 다른 것을 고려하여 Time.deltaTime 을 곱해야한다.
        rotateSpeed = 150;
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime , Space.World);
        // transform.Rotate(new Vector3(0,0,-1) * rotateSpeed * Time.deltaTime , Space.World);
        
    }




    // 비활성화 구간에는 컴포넌트가 활성화 되지 않을 수 있다!!!!

    // // OnTriggerEnter 닿았다며
    // void OnTriggerEnter(Collider other)
    // {
    //     if(other.name == "player"){
    //         // 다른 컴포넌트를 가져올 때 
    //         // 다른 C# 파일 변수이름 = other.GetComponent<다른 C# 파일>(); 
    //         player player=other.GetComponent<player>();
    //         player.itemCount++;  // 점수 추가
    //         audio.Play(); // 사운드 작동
    //         gameObject.SetActive(false);
    //     }
    // }
}
