using UnityEngine;

public class UFO : Enemy
{
    [SerializeField] Rigidbody body;
    [SerializeField] float movingSpeed;
    [SerializeField] float rotatingSpeed;

    [SerializeField] Transform target;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
        //move forward
        Vector3 movingForce = transform.forward * movingSpeed * Time.fixedDeltaTime;
        body.AddForce(movingForce);

        //rotate
        Vector3 targetAzimuth = target.transform.position - transform.position;
        float direction = Vector3.SignedAngle(transform.forward, targetAzimuth, Vector3.up);
        Vector3 rotatingForce = transform.up * Mathf.Sign(direction) * rotatingSpeed * Time.fixedDeltaTime;
        body.AddTorque(rotatingForce);
    }
}
