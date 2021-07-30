using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody body;
    [SerializeField] float movingSpeed;
    [SerializeField] float rotatingSpeed;
    [SerializeField] GameEvent gameOver;

    private void FixedUpdate()
    {
        //move forward
        if(Input.GetAxis("Vertical") > 0)
        {
            Vector3 movingForce = transform.forward * movingSpeed * Input.GetAxis("Vertical") * Time.fixedDeltaTime;
            body.AddForce(movingForce);
        }

        //rotate
        Vector3 rotatingForce = transform.up * rotatingSpeed * Input.GetAxis("Horizontal") * Time.fixedDeltaTime;
        body.AddTorque(rotatingForce);
    }

    //if goes out of screen
    private void OnBecameInvisible()
    {
        transform.position = new Vector3(-transform.position.x, 0, -transform.position.z);
    }

    //killed by enemy
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            gameOver.Raise();
            gameObject.SetActive(false);
        }
    }

}
