using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public ScoreEvent OnKill;
    [SerializeField] int scorePoints;
    
    //killed by ammo
    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ammo"))
        {
            OnKill.Raise(scorePoints);
            gameObject.SetActive(false);
        }
    }

    //on restart
    public void GameOver()
    {
        gameObject.SetActive(false);
    }
}
