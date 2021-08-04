using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Player player;
    
    public void Quit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        player.gameObject.SetActive(true);
        player.Restart();
    }
}
