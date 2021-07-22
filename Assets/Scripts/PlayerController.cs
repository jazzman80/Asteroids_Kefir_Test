using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody body;

    [SerializeField] private float rotationSpeed;
    [SerializeField] private float movingSpeed;

    private void FixedUpdate()
    {
        //move forward
        if (Input.GetAxis("Vertical") > 0)
        {
            float speed = Input.GetAxis("Vertical") * movingSpeed * Time.fixedDeltaTime;
            body.AddForce(transform.forward * speed);
        }
        
        //rotate
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed * Time.fixedDeltaTime;
        body.AddTorque(transform.up * rotation);
    }

    //if starship moved out of screen
    private void OnBecameInvisible()
    {
        transform.position = new Vector3(-transform.position.x, 0, -transform.position.z);
    }
}
