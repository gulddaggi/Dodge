using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float spawnRateMin = 0.5f; // 최소 생성 주기
    public float spawnRateMax = 3f; // 최대 생성 주기

    private Transform target;
    private float spawnRate; // 생성 주기. spawnRateMin 과 spawnRateMax 사이 랜덤값
    private float timeAfterSpawn; // 최근 생성 시점에서 지난 시간

    void Start()
    {
        timeAfterSpawn = 0f; // 0으로 초기화
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        // PlayerController가 존재하는 오브젝트의 transform을 target으로 설정
        target = FindObjectOfType<PlayerController>().transform; 
    }

    void Update()
    {
        timeAfterSpawn += Time.deltaTime;

        if (timeAfterSpawn >= spawnRate)
        {
            // 초기화
            timeAfterSpawn = 0f;

            // bullet 오브젝트 생성.
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

            // 생성된 bullet 오브젝트의 정면이 target을 향하도록 회전
            bullet.transform.LookAt(target); 

            // 생성 주기를 다시 랜덤 지정
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }
}
