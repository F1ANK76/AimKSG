using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTarget : MonoBehaviour
{
    public float moveRange = 7.0f;     // 원래 위치로부터 이동 가능한 거리
    public float moveSpeed = 0.5f;     // 이동 속도
    public Transform player;

    private Vector3 basePosition;

    void Start()
    {
        basePosition = transform.position;
    }

    void Update()
    {
        // x, z 방향으로만 움직이게 (y축 고정)
        float offsetX = Mathf.PerlinNoise(Time.time * moveSpeed, 0f) - 0.5f;
        float offsetZ = Mathf.PerlinNoise(0f, Time.time * moveSpeed) - 0.5f;

        Vector3 offset = new Vector3(offsetX, 0f, offsetZ) * moveRange * 2f;
        transform.position = basePosition + offset;

        if (player != null)
        {
            transform.LookAt(player);
            transform.Rotate(0f, 180f, 0f);
        }
    }
}

