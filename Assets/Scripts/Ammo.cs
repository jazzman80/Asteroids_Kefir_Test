using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] Rigidbody body;

    public void Fire(Transform direction, float force)
    {
        transform.position = direction.position;
        transform.rotation = direction.rotation;
        body.AddForce(direction.forward * force, ForceMode.Impulse);
    }

    //if goes out of screen
    private void OnBecameInvisible()
    {
        body.velocity = Vector3.zero;
        gameObject.SetActive(false);
    }
}
