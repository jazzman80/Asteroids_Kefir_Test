using UnityEngine;
using FMODUnity;

public class Enemy : MonoBehaviour
{
    public ScoreEvent OnKill;
    public int visualMode;
    [SerializeField] int scorePoints;
    [SerializeField] GameObject visualSprite;
    [SerializeField] GameObject visual3D;
    [SerializeField] StudioEventEmitter explosionSound;

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
            explosionSound.Play();
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
