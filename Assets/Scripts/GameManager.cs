using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool gameStarted;
    public Text scoreText;
    public Text highscoreText;
    private int score;

    private void Awake()
    {
        highscoreText.text = GetHighscore().ToString();
    }

    public void StartGame()
    {
        gameStarted = true;
        FindObjectOfType<Road>().StartBuilding();
    }

    public void EndGame()
    {
        SceneManager.LoadScene(0);
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartGame();
        }
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
        if (score > GetHighscore())
        {
            PlayerPrefs.SetInt("Highscore", score);
            highscoreText.text = score.ToString();
        }
    }

    public int GetHighscore()
    {
        int i = PlayerPrefs.GetInt("Highscore");
        return i;
    }
}
