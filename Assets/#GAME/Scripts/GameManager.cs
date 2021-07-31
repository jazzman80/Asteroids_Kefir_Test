using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] GameScoreText gameScoreText;
    
    public void Quit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        player.gameObject.SetActive(true);
        player.Restart();

        gameScoreText.gameObject.SetActive(true);
        gameScoreText.Restart();
    }
}
