using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TargetSpawner : MonoBehaviour
{
    public GameObject targetPrefab;  // 생성할 과녁 프리팹

    private BoxCollider spawnArea;   // 스폰 영역 콜라이더
    private GameObject currentTarget;

    void Start()
    {
        spawnArea = GetComponent<BoxCollider>(); // 같은 오브젝트에 붙은 BoxCollider 가져오기
        SpawnTarget();
    }

    public void SpawnTarget()
    {
        if (currentTarget != null)
        {
            Destroy(currentTarget);
        }

        // 스폰 영역 중심과 크기 계산
        Vector3 center = spawnArea.center + transform.position;
        Vector3 size = spawnArea.size;

        // 영역 내 랜덤 위치 계산
        Vector3 randomPos = new Vector3(
            Random.Range(center.x - size.x / 2, center.x + size.x / 2),
            Random.Range(center.y - size.y / 2, center.y + size.y / 2),
            Random.Range(center.z - size.z / 2, center.z + size.z / 2)
        );

        // 과녁 프리팹 생성
        currentTarget = Instantiate(targetPrefab, randomPos, Quaternion.identity);
    }
}

