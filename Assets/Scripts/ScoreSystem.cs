using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField]
    private int currentScore = 0;

    private Text scoreText;

    public bool gameOverScene = false;
    
    void Start()
    {
        GameObject scoreTextObj = GameObject.Find("ScoreText");
        if (scoreTextObj != null)
        {
            scoreText = scoreTextObj.GetComponent<Text>();            
        }
        UpdateScore();
    }

    private void UpdateScore()
    {
        if (scoreText != null)
        {
            scoreText.text = "";
            scoreText.text += "Hi-Score: " + GetHiScore() + "\n";

            if (!gameOverScene)
                scoreText.text += "Score: " + GetScore();
            else
                scoreText.text += "Score: " + GetCurrentScore();
        }
    }
    
    public int GetScore()
    {
        return currentScore;
    }

    public void GainScore(int scoreAmount)
    {
        currentScore += scoreAmount;
        SaveScore();
        UpdateScore();
    }

    public int LoadScore()
    {
        int hiScore = 0;

        if (PlayerPrefs.HasKey("HiScore"))
        {
            hiScore = PlayerPrefs.GetInt("HiScore");
        }
        return hiScore;
    }

    public void SaveScore()
    {
        PlayerPrefs.SetInt("CurrentScore", currentScore);
        if (PlayerPrefs.HasKey("HiScore"))
        {
            int hiScore = PlayerPrefs.GetInt("HiScore");
            if (currentScore > hiScore)
            {
                PlayerPrefs.SetInt("HiScore", currentScore);
            }
        }
        else
        {
            PlayerPrefs.SetInt("HiScore", currentScore);
        }
        PlayerPrefs.Save();
    }

    public int GetHiScore()
    {
        if (PlayerPrefs.HasKey("HiScore"))
        {
            return PlayerPrefs.GetInt("HiScore");
        }
        return 0;
    }

    public int GetCurrentScore()
    {
        if (PlayerPrefs.HasKey("CurrentScore"))
        {
            return PlayerPrefs.GetInt("CurrentScore");
        }
        return 0;
    }
}