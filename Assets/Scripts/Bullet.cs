using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody body;

    public void Fired(Transform gunTransform, float fireForce)
    {
        transform.position = gunTransform.position;
        transform.rotation = gunTransform.rotation;

        body.AddForce(transform.forward * fireForce, ForceMode.Impulse);
    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
