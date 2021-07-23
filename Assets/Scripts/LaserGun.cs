using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGun : MonoBehaviour
{
    [SerializeField] private Laser laser;
    [SerializeField] private float shotTime;
    [SerializeField] private float chargeTime;
    private bool laserIsCharged = true;

    private void Update()
    {
        if (Input.GetButtonDown("Fire2") && laserIsCharged)
        {
            laser.Fire(transform, shotTime);
            laserIsCharged = false;
            StartCoroutine(ChargeLaser());
        }
    }

    private IEnumerator ChargeLaser()
    {
        yield return new WaitForSeconds(chargeTime);
        laserIsCharged = true;
    }
}
