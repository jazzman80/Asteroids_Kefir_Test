using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfScreenTurnOff : MonoBehaviour
{
    [SerializeField] Rigidbody body;
    
    private void OnBecameInvisible()
    {
        body.velocity = Vector3.zero;
        body.angularVelocity = Vector3.zero;
        gameObject.SetActive(false);
    }
}
