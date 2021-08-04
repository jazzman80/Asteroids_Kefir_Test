using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public ScoreEvent OnKill;
    public int visualMode;
    [SerializeField] int scorePoints;
    [SerializeField] GameObject visualSprite;
    [SerializeField] GameObject visual3D;

    private void OnEnable()
    {
        SetVisualMode(visualMode);
    }

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

    //on visual mode change
    public void SetVisualMode(int mode)
    {
        if (mode == 0)
        {
            visual3D.SetActive(false);
            visualSprite.SetActive(true);
        }
        else if (mode == 1)
        {
            visual3D.SetActive(true);
            visualSprite.SetActive(false);
        }
    }
}
