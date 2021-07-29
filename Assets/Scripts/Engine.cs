using UnityEngine;

public class Engine : MonoBehaviour
{
    [SerializeField] GameObject fire;

    private void Update()
    {
        if (!fire.activeSelf && Input.GetAxis("Vertical") > 0) fire.SetActive(true);
        if (fire.activeSelf && Input.GetAxis("Vertical") == 0) fire.SetActive(false);
    }
}
