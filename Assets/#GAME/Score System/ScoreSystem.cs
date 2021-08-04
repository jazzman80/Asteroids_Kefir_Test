using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI gameScoreText;
    
    public int score;

    public void UpdateScore(int scoreUpdate)
    {
        score += scoreUpdate;
        gameScoreText.text = score.ToString();
    }

    public void Restart()
    {
        score = 0;
        gameScoreText.text = "0";
    }
}
