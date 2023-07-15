using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int highScore;
    public int playerScore;

    public Text currentScoreText;
    public Text highScoreText;
    public GameObject gameOverScreen;
    public AudioSource pointAudio;
    public AudioSource highScoreAudio;

    private void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore");
        highScoreText.text = highScore.ToString();
    }

    [ContextMenu("Increment Score")]
    public void addScore(int scoreToAdd)
    {
        playerScore = playerScore + scoreToAdd;
        currentScoreText.text = playerScore.ToString();
        pointAudio.Play();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void gameOver() 
    {
        saveHighScore();
        gameOverScreen.SetActive(true);
    }

    public void saveHighScore()
    {
        if(highScore < playerScore)
        {
            highScoreAudio.Play();
            PlayerPrefs.SetInt("HighScore", playerScore);
            highScoreText.text = highScore.ToString();
        }
    }
}
