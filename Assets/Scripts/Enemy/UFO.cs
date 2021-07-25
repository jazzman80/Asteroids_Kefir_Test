using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO : Enemy
{
    [SerializeField] private Rigidbody body;
    [SerializeField] private float movingSpeed;
    [SerializeField] private float rotationSpeed;

    private void FixedUpdate()
    {
        float targetDirection = Vector3.SignedAngle(transform.forward, target.position - transform.position, transform.up);

        body.AddTorque(transform.up * rotationSpeed * Time.fixedDeltaTime * Mathf.Sign(targetDirection));
        
        body.AddForce(transform.forward * movingSpeed * Time.fixedDeltaTime);
    }
}
