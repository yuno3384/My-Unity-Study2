using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private Player3 player;
    public float speed = 2f;
    public float time =0 ;
    public float hittingPoint = -3f;

    public float spawnInterval = 2.5f; // 장애물 생성 간격
    public float minX = -2.2f;
    public float maxX = 2.2f;
    public float spawnY = 5f;

    // 다음 장애물을 생성해야 할 시점을 저장할 변수
    private float nextSpawnTime;

    // ⭐️ 현재 활성화된 장애물을 추적할 리스트
    private List<GameObject> activeObstacles = new List<GameObject>();
    // ⭐️ 최대 활성 장애물 수 제한
    public int maxConcurrentObstacles = 1;

    private static bool objectCreated = false; // 시간 판정 및 장애물 갯수 판정
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 게임 시작 후 바로 생성되도록 첫 생성 시간을 0으로 설정
        nextSpawnTime = 0f;

        player = GameObject.FindAnyObjectByType<Player3>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        float distance = speed * Time.deltaTime;

        Vector3 direction = Vector3.down;

        transform.position += direction.normalized * distance;

        if (time >= 3f)
        {
            objectCreated = true;
            time = 0f;
        }
        
        if (objectCreated)
        {
            SpawnObstacle(); // 대량 발
            objectCreated = false;
        }

        if (transform.position.y < -6f)
        {
            Destroy(this.gameObject);
            Debug.Log("적이 소멸");
        }
        // 현재 게임 시간(Time.time)이 다음 생성 시점(nextSpawnTime)보다 크거나 같으면
        //if (activeObstacles.Count < maxConcurrentObstacles && Time.time >= nextSpawnTime)
        //{
        //    SpawnObstacle();

        //    // 다음 생성 시점을 현재 시간 + 설정한 간격으로 재설정합니다.
        //    nextSpawnTime = Time.time + spawnInterval;
        //}

    }

    //이 함수는 InvokeRepeating 예시와 동일합니다.
    void SpawnObstacle()
    {
        float randomX = Random.Range(minX, maxX);
        Vector3 spawnPosition = new Vector3(randomX, spawnY, 0f);
        Instantiate(gameObject, spawnPosition, Quaternion.identity);

    }






}
