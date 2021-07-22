using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private float fireForce;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Bullet newBullet = Instantiate(bulletPrefab);
            newBullet.Fired(transform, fireForce);
        }
    }
}
