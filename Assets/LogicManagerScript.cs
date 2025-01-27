using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicManagerScript : MonoBehaviour
{
    public GameObject gameOverScreen;
    public Text overText;

    public int score = 0;
    public Text scoreText;

    public Text bestScoreText;

    public int time = 60;
    public Text timeText;

    private float timer = 0f;

    public bool endGame = false;

    private static int bestScore = 0;

    void Start()
    {
        endGame = false;
        bestScoreText.text = "Best Score: " + bestScore.ToString();
    }

    void Update()
    {
        // Only start the timer if the game has not ended
        if (!endGame)
        {
            timer += Time.deltaTime;

            // Check if 1 second has passed
            if (timer >= 1f)
            {
                time -= 1;
                timeText.text = time.ToString();
                // Reset the timer
                timer = 0f;

                // Check if time has run out
                if (time <= 0)
                {
                    endGame = true;
                    endGameNow();
                }
            }
        }
    }

    public void addScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = score.ToString();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void endGameNow()
    {
        // Update the best score if the current score is higher
        if (score > bestScore)
        {
            bestScore = score;
        }

        bestScoreText.text = "Best Score: " + bestScore.ToString();
        if (score >= 10)
        {
            overText.text = "You Win!!!";
        }
        else
        {
            overText.text = "Game Over!!!";
        }

        gameOverScreen.SetActive(true);
    }
}
