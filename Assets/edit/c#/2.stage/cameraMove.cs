using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMove : MonoBehaviour
{
    Transform playerTransform;
    Vector3 Offset;
   
   
    void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        // 카메라와 오브젝트의 차이값
        // transform.position(스크립트의 위치 값)
        // playerTransform.position (플레이어의 위치 값)
        Offset = transform.position - playerTransform.position;
    }

    //업데이트 이후에 실행
    // ui 와 카메라 이동에서 많이 사용됨
    // update 에서 연산을 다하고
    // 그 뒤에 따라붙는 것이기 때문에
    void LateUpdate()
    {
        // 조종값을 더하게 되면 카메라가 원래 잡아놨던 위치에 고정 시킬 수 있다.
        transform.position = playerTransform.position + Offset;
    }
}
