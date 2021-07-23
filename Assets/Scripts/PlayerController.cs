using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody body;

    [SerializeField] private float rotationSpeed;
    [SerializeField] private float movingSpeed;
    [SerializeField] private GameObject engines;

    private void FixedUpdate()
    {
        //move forward
        if (Input.GetAxis("Vertical") > 0)
        {
            float speed = Input.GetAxis("Vertical") * movingSpeed * Time.fixedDeltaTime;
            body.AddForce(transform.forward * speed);
            if (!engines.activeSelf) engines.SetActive(true);
        }
        else engines.SetActive(false);
        
        //rotate
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed * Time.fixedDeltaTime;
        body.AddTorque(transform.up * rotation);
    }
}
