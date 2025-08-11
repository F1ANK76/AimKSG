using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int score = 0;
    public int Score => score;  // score ���� �б� �������� �ܺ� ����
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
        UIManager.Instance.UpdateScoreText(score);  // UI ����
    }
}

