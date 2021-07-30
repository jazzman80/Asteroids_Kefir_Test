using System.Collections;
using UnityEngine;

public class LaserGun : Gun
{
    [SerializeField] float chargeTime;
    [SerializeField] int maximumCharge;
    int charge;
    bool isCharged = true;

    private void Start()
    {
        charge = maximumCharge;
    }

    public override bool CheckFire()
    {
        if (Input.GetButtonDown(fireButton) && charge > 0) return true;
        else return false;
    }

    public override void Fire(Ammo ammo)
    {
        ammo.Fire(transform, fireForce);
        //isCharged = false;
        if(charge > 0) charge--;

        StopAllCoroutines();
        StartCoroutine(Charge());
    }

    IEnumerator Charge()
    {
        yield return new WaitForSeconds(chargeTime);
        //isCharged = true;
        charge++;
        if (charge < maximumCharge) StartCoroutine(Charge());
    }
}
