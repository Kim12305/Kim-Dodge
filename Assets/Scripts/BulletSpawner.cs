using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab; //원본 탄알의 프리팹
    public float spawnRateMin = 0.5f; // 최소 생성 주기
    public float spawnRateMax = 3f; //최대 생성 주기
    public bool isShot = true;

    private Transform target; //발사할 대상
    private float spawnRate; // 생성 주기
    private float timeAfterSpawn; //최근 생성 시점에서 지난 시간

    // Start is called before the first frame update
    void Start()
    {
        timeAfterSpawn = 0f; //최근 생성 이후 누적 시간을 0으로 초기화
        Random.Range(spawnRateMin, spawnRateMax); //최소와 최대값 설정해서 랜덤화 시킨다

        //플레이어 컴포넌트를 가진 게임 오브젝트를 찾아 조준 대상으로 설정
        target = FindObjectOfType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (isShot == true)
        {
            //timeAfterSpawn 갱신
            timeAfterSpawn += Time.deltaTime;

            //최근 생성 시점부터 누적된 시간이 주기보다 크거나 같을 때!
            if (timeAfterSpawn >= spawnRate)
            {
                //누적된 시간 리셋
                timeAfterSpawn = 0f;

                //탄알의 복제본을 위치와 회전을 설정하여 생성한다
                GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

                //생성된 탄알 방향이 플레이어를 향하도록 생성
                bullet.transform.LookAt(target);

                //다음 번 생성 간격을 최솟값과 최대값 사이에서 랜덤 지정
                spawnRate = Random.Range(spawnRateMin, spawnRateMax);
            }

        }
        if (PlayerController.hp <= 0)
        {
            isShot = false;
        }
    }
}



 