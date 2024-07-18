using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    public float jumpPower; // 점프 파워
    public int itemCount;// 점수
    public manager manager;
    bool isJump;    // 점프를 했는지 안 했는지
    public AudioSource[] audio; // 사운드 컴포넌트 선언
    Rigidbody rigid; // 선언
    
    void Awake()
    {
        isJump = false;
        rigid = GetComponent<Rigidbody>(); // 초기화
        audio = GetComponents<AudioSource>(); // 사운드 컴포넌트 초기화
        itemCount = 0;
      
    }





    void Update()
    {
        jumpPower = 25;
        // 1단 점프
        if (Input.GetButtonDown("Jump") && !isJump)
        {
            audio[1].Play();
            isJump = true;
            rigid.AddForce(new Vector3(0,jumpPower,0) , ForceMode.Impulse);
        }
    }



    void FixedUpdate()
    {
   
        // 기본적인 이동
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        rigid.AddForce(new Vector3(h,0,v) , ForceMode.Impulse);

    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "floor")
        {
            isJump = false;
        }
    }


    // OnTriggerEnter 닿았다면
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "item") // Assuming the name of the item is "item"
        {
            itemCount++;  // Increment the score
            audio[0].Play(); // Play the sound
            // rigid.AddForce(new Vector3(0,jumpPower,0) , ForceMode.Impulse);

            // Deactivate the collided item
            other.gameObject.SetActive(false);
            manager.GetItem(itemCount);
        }



        else if(other.tag == "jump_item_50") // Assuming the name of the item is "item"
        {
            audio[3].Play();
            rigid.AddForce(new Vector3(0,50,0) , ForceMode.Impulse);
            other.gameObject.SetActive(false);
        }

        
        else if(other.tag == "fail") // Assuming the name of the item is "item"
        {
            audio[2].Play();
        }


        else if (other.tag == "finish")
        {
            if (itemCount == manager.TotalItemCount)
            {
                // 게임 클리어 >> 다음 레벨로!!!
                if (manager.stage ==5)  // 마지막 스테이지라면 처음으로 돌아가라
                    SceneManager.LoadScene(6);
                else
                    SceneManager.LoadScene(manager.stage+1);

            }

            else
            {
                // 다시 시작
                SceneManager.LoadScene(manager.stage);
            }

        }
 
    }


}