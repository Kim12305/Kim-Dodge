using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f; //탄알 이동 속력
    private Rigidbody bulletRigidbody; //이동에 사용할 리지드 바디 컴포넌트


    void Start()
    {
        
        bulletRigidbody = GetComponent<Rigidbody>();

        //리지드바디 속도 = 방향* 이동속력
        bulletRigidbody.velocity = transform.forward * speed;

        //3초뒤에 탄알 삭제
        Destroy(gameObject, 3f);
    }

    //충돌할 시
    void OnTriggerEnter(Collider other)
    {
        //충돌한 상대방 오브젝트가 player 태그를 가진 경우
        PlayerController playerController = other.GetComponent<PlayerController>();

        //상대방으로부터 컴포넌트 가져오는데 성공하면?
        if(playerController != null)
        {
            //상대방으로부터 플레이어 컴포넌트 Die메서드 실행
            playerController.Die();


        }
    }
   
}
