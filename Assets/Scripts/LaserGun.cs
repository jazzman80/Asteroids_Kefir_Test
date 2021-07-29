using System.Collections;
using UnityEngine;

public class LaserGun : Gun
{
    [SerializeField] float chargeTime;
    bool isCharged = true;

    public override bool CheckFire()
    {
        if (Input.GetButtonDown(fireButton) && isCharged) return true;
        else return false;
    }

    public override void Fire(Ammo ammo)
    {
        ammo.Fire(transform, fireForce);
        isCharged = false;
        StartCoroutine(Charge());
    }

    IEnumerator Charge()
    {
        yield return new WaitForSeconds(chargeTime);
        isCharged = true;
    }
}
