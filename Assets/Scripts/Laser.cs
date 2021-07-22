using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private void Start()
    {
        this.gameObject.SetActive(false);
    }

    public void Fired(Transform laserGunTransform, float shotTime)
    {
        this.gameObject.SetActive(true);
        transform.position = laserGunTransform.position;
        transform.rotation = laserGunTransform.rotation;
        StartCoroutine(LaserFire(shotTime));
    }

    private IEnumerator LaserFire(float shotTime)
    {
        yield return new WaitForSeconds(shotTime);
        this.gameObject.SetActive(false);
    }
}
