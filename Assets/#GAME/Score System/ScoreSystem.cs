using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public int score;

    public void UpdateScore(int scoreUpdate)
    {
        score += scoreUpdate;
    }

    public void Restart()
    {
        score = 0;
    }
}
