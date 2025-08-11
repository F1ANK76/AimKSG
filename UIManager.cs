using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;  // Button 클래스 사용하려면 필요

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("UI Elements")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI rankText;

    public GameObject gameOverPanel;  // 게임오버 UI 패널
    public Button retryButton;        // 리트라이 버튼 추가

    [Header("Timer Settings")]
    public float totalTime = 60f; // 1분
    private float remainingTime;
    private bool isTimerRunning = true;
    private void Awake()
    {
        Instance = this;
        UpdateScoreText(0);
        remainingTime = totalTime;

        if(gameOverPanel)
        {
            gameOverPanel.SetActive(false);
        }
    }

    private void Update()
    {
        if (isTimerRunning)
        {
            if (remainingTime > 1f)
            {
                remainingTime -= Time.deltaTime;
                UpdateTimerText(remainingTime);
            }
            else
            {
                isTimerRunning = false;
                remainingTime = 0f;
                UpdateTimerText(remainingTime);

                ShowGameOverUI();
            }
        }
    }

    private void ShowGameOverUI()
    {
        gameOverPanel.SetActive(true);  // 게임오버 UI 켜기
        Time.timeScale = 0f;            // 게임 정지

        Cursor.visible = true;          // 마우스 커서 보이게
        Cursor.lockState = CursorLockMode.None;  // 커서 잠금 해제

        UpdateRankText(GameManager.Instance.Score);
    }
    private void UpdateRankText(int score)
    {
        Scene currentScene = SceneManager.GetActiveScene();

        if (currentScene.name == "MainScene")
        {
            if (score < 100) rankText.text = "Rank : Bronze";
            else if (score < 250) rankText.text = "Rank : Silver";
            else if (score < 400) rankText.text = "Rank : Gold";
            else if (score < 550) rankText.text = "Rank : Platinum";
            else if (score < 700) rankText.text = "Rank : Diamond";
            else if (score < 850) rankText.text = "Rank : Master";
            else if (score < 1000) rankText.text = "Rank : Grandmaster";
            else rankText.text = "Rank : Challenger";
        }
        else if(currentScene.name == "MainScene2")
        {
            if (score < 100) rankText.text = "Rank : Bronze";
            else if (score < 150) rankText.text = "Rank : Silver";
            else if (score < 200) rankText.text = "Rank : Gold";
            else if (score < 250) rankText.text = "Rank : Platinum";
            else if (score < 300) rankText.text = "Rank : Diamond";
            else if (score < 350) rankText.text = "Rank : Master";
            else if (score < 400) rankText.text = "Rank : Grandmaster";
            else rankText.text = "Rank : Challenger";
        }
        else if (currentScene.name == "MainScene3")
        {
            if (score < 1000) rankText.text = "Rank : Bronze";
            else if (score < 1500) rankText.text = "Rank : Silver";
            else if (score < 2000) rankText.text = "Rank : Gold";
            else if (score < 2500) rankText.text = "Rank : Platinum";
            else if (score < 3000) rankText.text = "Rank : Diamond";
            else if (score < 4000) rankText.text = "Rank : Master";
            else if (score < 5000) rankText.text = "Rank : Grandmaster";
            else rankText.text = "Rank : Challenger";
        }
    }
    public void UpdateScoreText(int score)
    {
        if (scoreText)
        {
            scoreText.text = "Score : " + score;
        }
    }

    public void UpdateTimerText(float time)
    {
        if(timerText)
        {
            int minutes = Mathf.FloorToInt(time / 60f);
            int seconds = Mathf.FloorToInt(time % 60f);
            timerText.text = $"Time : {minutes:00}:{seconds:00}";
        }
    }

    public void OnRetryButton()
    {
        Time.timeScale = 1f;  // 게임 정지 해제
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // 씬 다시 불러오기
    }

    public void OnGoHomeButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainIntro");
    }

    public void LoadStage(string sceneName)
    {
        Time.timeScale = 1f; // 혹시 시간 정지된 상태일 수도 있으니
        SceneManager.LoadScene(sceneName);
    }
}
