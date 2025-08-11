using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner2 : MonoBehaviour
{
    public GameObject targetPrefab;    // 생성할 과녁 프리팹
    public Transform player;           // 플레이어 Transform
    public float spawnDistance = 10f;   // 플레이어로부터 거리

    private GameObject currentTarget;

    void Start()
    {
        SpawnTarget();
    }

    public void SpawnTarget()
    {
        if (currentTarget != null)
            Destroy(currentTarget);

        // 1. 기본 방향 정의
        Vector3[] directions = new Vector3[]
        {
            player.forward,     // 앞
            -player.forward,    // 뒤
            player.right,       // 우
            -player.right,      // 좌
            player.up           // 위
        };

        int randomIndex = Random.Range(0, directions.Length);
        Vector3 baseDir = directions[randomIndex];

        // 2. 방향에 약간의 각도 랜덤 오차 추가
        float maxAngle = 20f; // 최대 오차 각도 (예: ±20도)
        float randomAngle = Random.Range(-maxAngle, maxAngle);

        // 회전축 결정 (위쪽이면 z축 회전으로 자연스러움 처리)
        Vector3 rotationAxis = (baseDir == Vector3.up) ? Vector3.forward : Vector3.up;

        // chosenDir 계산
        Vector3 chosenDir = Quaternion.AngleAxis(randomAngle, rotationAxis) * baseDir;

        // 3. 고정된 높이에서 위치 계산
        Vector3 spawnPos = player.position + chosenDir.normalized * spawnDistance;
        spawnPos.y = player.position.y + spawnDistance; // 고정 높이

        // 4. 과녁 생성
        currentTarget = Instantiate(targetPrefab, spawnPos, Quaternion.identity);
        currentTarget.transform.LookAt(player);
        currentTarget.transform.Rotate(0f, 180f, 0f);
    }
}