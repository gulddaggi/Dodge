using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float spawnRateMin = 0.5f; // �ּ� ���� �ֱ�
    public float spawnRateMax = 3f; // �ִ� ���� �ֱ�

    private Transform target;
    private float spawnRate; // ���� �ֱ�. spawnRateMin �� spawnRateMax ���� ������
    private float timeAfterSpawn; // �ֱ� ���� �������� ���� �ð�

    void Start()
    {
        timeAfterSpawn = 0f; // 0���� �ʱ�ȭ
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        // PlayerController�� �����ϴ� ������Ʈ�� transform�� target���� ����
        target = FindObjectOfType<PlayerController>().transform; 
    }

    void Update()
    {
        timeAfterSpawn += Time.deltaTime;

        if (timeAfterSpawn >= spawnRate)
        {
            // �ʱ�ȭ
            timeAfterSpawn = 0f;

            // bullet ������Ʈ ����.
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

            // ������ bullet ������Ʈ�� ������ target�� ���ϵ��� ȸ��
            bullet.transform.LookAt(target); 

            // ���� �ֱ⸦ �ٽ� ���� ����
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }
}
