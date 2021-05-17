using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText; //게임오버시 활성화되는 텍스트
    public Text timeText; //시간표시
    public Text recordResultText; //최고기록
    public Text rotationText;

    public GameObject level; //레벨을 수정할 변수
    public GameObject bullerSpawnerPrefab;

    private Vector3[] bulletSpawners = new Vector3[4];
    int spawnCounter = 0;

    public float surviveTime;
    public bool isGameover;

    // Start is called before the first frame update
    void Start()
    {
        surviveTime = 0; //생존 시간 
        isGameover = false;

        bulletSpawners[0].x = -9.5f;
        bulletSpawners[0].y = 1f;
        bulletSpawners[0].z = 10f;

        bulletSpawners[1].x = 9.5f;
        bulletSpawners[1].y = 1f;
        bulletSpawners[1].z = 10f;

        bulletSpawners[2].x = 9.5f;
        bulletSpawners[2].y = 1f;
        bulletSpawners[2].z = -10f;

        bulletSpawners[3].x = -9.5f;
        bulletSpawners[3].y = 1f;
        bulletSpawners[3].z = -10f;

    }

    // Update is called once per frame
    void Update()
    {
        if(!isGameover) //게임오버 안될 때 5초씩 증가하면 추가한다
        {
            surviveTime += Time.deltaTime;
            timeText.text = "Time : " + (int)surviveTime;
            rotationText.text = "Speed : " + level.GetComponent<Rotator>().rotationSpeed;

            if (surviveTime < 5f && spawnCounter == 0)
            {
                GameObject bulletSpawner = Instantiate(bullerSpawnerPrefab, bulletSpawners[spawnCounter], Quaternion.identity);
                bulletSpawner.transform.parent = level.transform;
                bulletSpawner.transform.localPosition = bulletSpawners[spawnCounter];
                level.GetComponent<Rotator>().rotationSpeed += 15f; 
                spawnCounter++;
            }

            else if (surviveTime >= 5f && surviveTime < 10f && spawnCounter == 1)
            {
                GameObject bulletSpawner = Instantiate(bullerSpawnerPrefab, bulletSpawners[spawnCounter], Quaternion.identity);
                bulletSpawner.transform.parent = level.transform;
                bulletSpawner.transform.localPosition = bulletSpawners[spawnCounter];
                level.GetComponent<Rotator>().rotationSpeed += 15f;
                spawnCounter++;
            }

            else if (surviveTime >= 10f && surviveTime < 15f && spawnCounter == 2)
            {
                GameObject bulletSpawner = Instantiate(bullerSpawnerPrefab, bulletSpawners[spawnCounter], Quaternion.identity);
                bulletSpawner.transform.parent = level.transform;
                bulletSpawner.transform.localPosition = bulletSpawners[spawnCounter];
                level.GetComponent<Rotator>().rotationSpeed += 15f;
                spawnCounter++;
            }

            else if (surviveTime >= 15f && surviveTime < 20f && spawnCounter == 3)
            {
                GameObject bulletSpawner = Instantiate(bullerSpawnerPrefab, bulletSpawners[spawnCounter], Quaternion.identity);
                bulletSpawner.transform.parent = level.transform;
                bulletSpawner.transform.localPosition = bulletSpawners[spawnCounter];
                level.GetComponent<Rotator>().rotationSpeed += 15f;
                spawnCounter++;
            }
        }

        else
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("SampleScene");
            }
        }

    }
        public void EndGame()
        {
            isGameover = true; 
            gameoverText.SetActive(true); //죽으면 게임오버 상태로

            //최고기록 가져오기
            float bestTime = PlayerPrefs.GetFloat("Best Time : ");

            if(surviveTime > bestTime)
            {
                bestTime = surviveTime;
                //변경된 최고 기록 저장
                PlayerPrefs.SetFloat("BestTime", bestTime);
            }

            //최고기록을 텍스트로 표시
            recordResultText.text = "Best Time : " + (int)bestTime;
        }
}
