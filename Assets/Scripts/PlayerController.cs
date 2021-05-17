using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRigidbody;//이동에 사용할 리지드 바디 컴포넌트 가져오기
    public float speed = 8f; //이동 속력
    public static int hp = 1;
   
    void Start()
    {
        //게임 오브젝트에서 Rigidbody 컴포넌트를 찾아 플레이어 리지드 바디에 할당
        playerRigidbody = GetComponent<Rigidbody>();
        hp = 1;
    }

  
    void Update()
    {
       
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        //실제 이동 속도를 입력값과 이동 속력을 사용해 결정
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        //Vector3 속도를 생성한다
        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);

        //vextor3의 속도에 newVelocity 할당
        playerRigidbody.velocity = newVelocity;
        

    }

    public void Die() //죽으면 오브젝트 비활성화
    {
        gameObject.SetActive(false);
        hp--;

        //게임매니저 가져오기
        GameManager gamemanager = FindObjectOfType<GameManager>();
        //게임매니저 오브젝트의 엔드게임 실행
        gamemanager.EndGame();

    }
}
