using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : Enemy
{
    [SerializeField] Rigidbody body;
    [SerializeField] float speed;
    private bool isActivated;

    private void Update()
    {
        if (!isActivated)
        {
            Vector3 target = (Vector3.zero - transform.position).normalized;
            body.AddForce(target * speed, ForceMode.Impulse);
        }

        if (!isActivated) isActivated = true;
    }

    private void OnDisable()
    {
        isActivated = false;
    }
}
