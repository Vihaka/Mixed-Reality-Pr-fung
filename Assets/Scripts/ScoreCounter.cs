using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    private int score;
    private int highScore;
    [SerializeField] private TextMeshPro scoreText;
    [SerializeField] private TextMeshPro highscoreText;

    void Start()
    {
        score = 0;
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        UpdateScoreText();
        UpdateHighScoreText();
    }

    public void IncrementScore()
    {
        score++;
        UpdateScoreText();
    }
    
    
    

    public void ResetScore()
    {
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            UpdateHighScoreText();
        }
        score = 0;
        UpdateScoreText();
        UpdateHighScoreText();
    }

    private void UpdateScoreText()
    {
        // Debug.Log("Score: " + score);
        if (scoreText != null)
        {
            scoreText.text = "" + score;
        }
        else
        {
            scoreText.text = "0";
        }
    }

    private void UpdateHighScoreText()
    {
        // Debug.Log("High Score: " + highScore);
        if (highscoreText != null)
        {
            highscoreText.text = "" + highScore;
        }
        else
        {
            highscoreText.text = "0";
        }
    }
}