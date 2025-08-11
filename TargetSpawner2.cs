using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner2 : MonoBehaviour
{
    public GameObject targetPrefab;    // ������ ���� ������
    public Transform player;           // �÷��̾� Transform
    public float spawnDistance = 10f;   // �÷��̾�κ��� �Ÿ�

    private GameObject currentTarget;

    void Start()
    {
        SpawnTarget();
    }

    public void SpawnTarget()
    {
        if (currentTarget != null)
            Destroy(currentTarget);

        // 1. �⺻ ���� ����
        Vector3[] directions = new Vector3[]
        {
            player.forward,     // ��
            -player.forward,    // ��
            player.right,       // ��
            -player.right,      // ��
            player.up           // ��
        };

        int randomIndex = Random.Range(0, directions.Length);
        Vector3 baseDir = directions[randomIndex];

        // 2. ���⿡ �ణ�� ���� ���� ���� �߰�
        float maxAngle = 20f; // �ִ� ���� ���� (��: ��20��)
        float randomAngle = Random.Range(-maxAngle, maxAngle);

        // ȸ���� ���� (�����̸� z�� ȸ������ �ڿ������� ó��)
        Vector3 rotationAxis = (baseDir == Vector3.up) ? Vector3.forward : Vector3.up;

        // chosenDir ���
        Vector3 chosenDir = Quaternion.AngleAxis(randomAngle, rotationAxis) * baseDir;

        // 3. ������ ���̿��� ��ġ ���
        Vector3 spawnPos = player.position + chosenDir.normalized * spawnDistance;
        spawnPos.y = player.position.y + spawnDistance; // ���� ����

        // 4. ���� ����
        currentTarget = Instantiate(targetPrefab, spawnPos, Quaternion.identity);
        currentTarget.transform.LookAt(player);
        currentTarget.transform.Rotate(0f, 180f, 0f);
    }
}