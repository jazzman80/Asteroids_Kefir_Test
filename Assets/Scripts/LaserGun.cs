using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGun : MonoBehaviour
{
    [SerializeField] Laser laser;
    [SerializeField] float shotTime;

    private void Update()
    {
        if (Input.GetButtonDown("Fire2")) laser.Fired(transform, shotTime);
    }
}
