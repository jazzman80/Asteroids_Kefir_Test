using UnityEngine;

public class OutOfScreenMirror : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        transform.position = new Vector3(-transform.position.x, 0, -transform.position.z);
    }
}
