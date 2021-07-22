using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private float fireForce;

    private List<Bullet> bulletsPool = new List<Bullet>();

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            bool isFired = false;

            for(int i=0; i < bulletsPool.Count; i++)
            {
                if (!bulletsPool[i].gameObject.activeSelf)
                {
                    bulletsPool[i].gameObject.SetActive(true);
                    bulletsPool[i].Fired(transform, fireForce);
                    isFired = true;
                    break;
                }
            }

            if(!isFired) InstantiateBullet();
        }
    }

    private void InstantiateBullet()
    {
        Bullet newBullet = Instantiate(bulletPrefab);
        bulletsPool.Add(newBullet);
        newBullet.Fired(transform, fireForce);
    }
}
