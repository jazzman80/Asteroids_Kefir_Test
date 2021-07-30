using UnityEngine;

public class Stone : Enemy
{
    [SerializeField] Rigidbody body;
    [SerializeField] float initialSpeed;
    [SerializeField] float randomSpeed;
    [SerializeField] float randomRotationSpeed;
    [SerializeField] float randomSize;
    [SerializeField] Vector3 scaleSize;

    public virtual void OnEnable()
    {
        transform.localScale = scaleSize;
        body.velocity = Vector3.zero;
        body.angularVelocity = Vector3.zero;

        SetRandomTrajectory();

        SetRandomSize();

        SetRandomSpeed();

        SetRandomRotation();
    }

    public virtual void SetRandomTrajectory()
    {
        float randomAngle = Random.Range(-20.0f, 20.0f);
        transform.Rotate(Vector3.up, randomAngle);
    }

    private void SetRandomSize()
    {
        float randomScale = Random.Range(-randomSize, randomSize);
        Vector3 scaling = new Vector3(randomScale, randomScale, randomScale);
        transform.localScale = scaleSize + scaling;
    }

    private void SetRandomSpeed()
    {
        float speed = initialSpeed + Random.Range(-randomSpeed, randomSpeed);
        Vector3 force = transform.forward * speed;
        body.AddForce(force, ForceMode.Impulse);
    }

    private void SetRandomRotation()
    {
        float rotationForce = Random.Range(-randomRotationSpeed, randomRotationSpeed);
        body.AddTorque(rotationForce * Vector3.up, ForceMode.Impulse);
    }

    //if goes out of screen
    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }

}
