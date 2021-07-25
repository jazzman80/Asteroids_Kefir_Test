using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : GameElement
{
    public Transform target;
    
    public void SetTarget(Transform target)
    {
        this.target = target;
    }

    public void SetPosition(Transform point)
    {
        gameObject.transform.position = point.position;
    }
    
    //killed by ammo
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ammo")) gameObject.SetActive(false);
    }
}
