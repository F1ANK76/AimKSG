using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TargetSpawner : MonoBehaviour
{
    public GameObject targetPrefab;  // ������ ���� ������

    private BoxCollider spawnArea;   // ���� ���� �ݶ��̴�
    private GameObject currentTarget;

    void Start()
    {
        spawnArea = GetComponent<BoxCollider>(); // ���� ������Ʈ�� ���� BoxCollider ��������
        SpawnTarget();
    }

    public void SpawnTarget()
    {
        if (currentTarget != null)
        {
            Destroy(currentTarget);
        }

        // ���� ���� �߽ɰ� ũ�� ���
        Vector3 center = spawnArea.center + transform.position;
        Vector3 size = spawnArea.size;

        // ���� �� ���� ��ġ ���
        Vector3 randomPos = new Vector3(
            Random.Range(center.x - size.x / 2, center.x + size.x / 2),
            Random.Range(center.y - size.y / 2, center.y + size.y / 2),
            Random.Range(center.z - size.z / 2, center.z + size.z / 2)
        );

        // ���� ������ ����
        currentTarget = Instantiate(targetPrefab, randomPos, Quaternion.identity);
    }
}

