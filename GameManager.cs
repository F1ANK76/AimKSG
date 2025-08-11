using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int score = 0;
    public int Score => score;  // score 값을 읽기 전용으로 외부 공개
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void ChangeScore(int amount)
    {
        score += amount;
        UIManager.Instance.UpdateScoreText(score);  // UI 갱신
    }
}

