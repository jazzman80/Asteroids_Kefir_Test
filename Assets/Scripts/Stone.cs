using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : Enemy
{
    [SerializeField] Rigidbody body;
    [SerializeField] float initialSpeed;
    [SerializeField] float randomSpeed;
    [SerializeField] float randomRotationSpeed;
    [SerializeField] float initialSize;
    [SerializeField] float randomSize;
    Vector3 scaling;
    Vector3 scaleSize;

    private void Start()
    {
        scaleSize = new Vector3(initialSize, initialSize, initialSize);
    }


    private void OnEnable()
    {
        //set random trajectory
        transform.LookAt(Vector3.zero);
        float randomAngle = Random.Range(-20.0f, 20.0f);
        transform.Rotate(Vector3.up, randomAngle);

        //set random size
        float randomScale = Random.Range(-randomSize, randomSize);
        scaling = new Vector3(randomScale, randomScale, randomScale);
        transform.localScale = scaleSize + scaling;

        //set random speed
        float speed = initialSpeed + Random.Range(-randomSpeed, randomSpeed);
        Vector3 force = transform.forward * speed;
        body.AddForce(force, ForceMode.Impulse);

        //set random rotation
        float rotationForce = Random.Range(-randomRotationSpeed, randomRotationSpeed);
        body.AddTorque(rotationForce * Vector3.up, ForceMode.Impulse);
    }


    private void OnBecameInvisible()
    {
        transform.localScale = scaleSize;
        body.velocity = Vector3.zero;
        body.angularVelocity = Vector3.zero;
        gameObject.SetActive(false);
    }
}
