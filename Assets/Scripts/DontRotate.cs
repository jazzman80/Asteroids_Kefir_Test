using UnityEngine;

public class DontRotate : MonoBehaviour
{
    Quaternion startRotation;
    void Start()
    {
        startRotation = transform.rotation;
    }
    void Update()
    {
        transform.rotation = startRotation;
    }
}
