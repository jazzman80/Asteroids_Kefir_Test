using UnityEngine;

public class Engine : MonoBehaviour
{
    [SerializeField] GameObject fire;
    [SerializeField] ParticleSystem particleFire;

    private void Update()
    {
        if (!fire.activeSelf && Input.GetAxis("Vertical") > 0)
        {
            fire.SetActive(true);
            particleFire.Play();
        }
        if (fire.activeSelf && Input.GetAxis("Vertical") == 0)
        {
            fire.SetActive(false);
            particleFire.Stop();
        }
    }
}
