using UnityEngine;

public class Bullet : Ammo
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy")) gameObject.SetActive(false);
    }
}
