using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    [SerializeField] private string killedBy;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(killedBy)) gameObject.SetActive(false);
    }
}
