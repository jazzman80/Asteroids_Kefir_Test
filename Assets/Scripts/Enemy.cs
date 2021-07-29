using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //killed by ammo
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ammo")) gameObject.SetActive(false);
    }
}
