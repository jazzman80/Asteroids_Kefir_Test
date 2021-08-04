using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    [SerializeField] ScoreSystem scoreSystem;
    [SerializeField] TextMeshProUGUI score;
    string scoreText;

    private void OnEnable()
    {
        scoreText = scoreSystem.score.ToString();
        score.text = "you scored<br>" + scoreText + "<br>points";
    }
}
