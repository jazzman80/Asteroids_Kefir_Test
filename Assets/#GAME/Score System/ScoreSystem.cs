using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] int score;

    public void UpdateScore(int scoreUpdate)
    {
        score += scoreUpdate;
    }
}
