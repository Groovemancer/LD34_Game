using UnityEngine;
using System.Collections;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField]
    private int currentScore = 0;
    
    public int GetScore()
    {
        return currentScore;
    }

    public void GainScore(int scoreAmount)
    {
        currentScore += scoreAmount;
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
}