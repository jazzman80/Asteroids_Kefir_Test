using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameScoreText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI gameScoreText;
    [SerializeField] ScoreSystem scoreSystem;

    public void OnScored()
    {
        gameScoreText.text = scoreSystem.score.ToString();
    }

    public void GameOver()
    {
        gameObject.SetActive(false);
    }

    public void Restart()
    {
        gameScoreText.text = "00";
    }
}
