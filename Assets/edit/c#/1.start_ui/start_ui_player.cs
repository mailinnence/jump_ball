using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start_ui_player : MonoBehaviour
{
    public float jumpPower;
    public float jumpCooldown = 1.0f; // 점프 쿨다운 시간 설정
    Rigidbody rigid;
    bool isGrounded; // 지면에 닿았는지 여부를 나타내는 변수

    float jumpTimer = 0.0f; // 점프 시간 측정을 위한 타이머

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        isGrounded = true; // 시작 시에는 지면에 있음을 가정
    }

    void FixedUpdate()
    {
        if (isGrounded && jumpTimer <= 0.0f) // 점프 쿨다운이 끝났을 때만 점프하도록 조건 추가
        {
            jumpPower = 5;
            rigid.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
            isGrounded = false; // 점프 시에는 지면에서 벗어났다고 설정
            jumpTimer = jumpCooldown; // 점프 후 쿨다운 시작
        }

        if (jumpTimer > 0.0f)
        {
            jumpTimer -= Time.fixedDeltaTime; // 점프 쿨다운 시간 감소
        }
    }

    // 충돌 감지
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            isGrounded = true;
        }
    }
}
