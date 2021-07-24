using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO : MonoBehaviour
{
    [SerializeField] private Rigidbody body;
    [SerializeField] private float movingSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] Transform target;

    private void FixedUpdate()
    {
        float targetDirection = Vector3.SignedAngle(transform.forward, target.position - transform.position, transform.up);

        body.AddTorque(transform.up * rotationSpeed * Time.fixedDeltaTime * Mathf.Sign(targetDirection));
        
        body.AddForce(transform.forward * movingSpeed * Time.fixedDeltaTime);
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
    }
}
