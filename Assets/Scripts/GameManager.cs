using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public float HighScore;
    public GameObject loseUI;
    public int points = 0;
    public TextMeshProUGUI scoreText;
    void Start()
    {
        HighScore = PlayerPrefs.GetInt(key:"key", defaultValue:0);
        PlayerPrefs.SetInt("key", 3);
        PlayerPrefs.GetString("string", "wartosc");
    }
    public void LoadData()
    {
        HighScore = DataManager.Instance.HighScore;
    }
    public void StartGame()
    {
        Time.timeScale = 1;
    }

    private void ShowLoseUI()
    {
        loseUI.SetActive(true);
    }

    public void RepeatGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
    }
    public void OnGameOver()
    {
        ShowLoseUI();
        Time.timeScale = 0;
    }

    public void UpdateScore()
    {
        points++;
        scoreText.text = points.ToString();
    }
}
