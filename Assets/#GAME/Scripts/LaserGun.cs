using System.Collections;
using UnityEngine;

public class LaserGun : Gun
{
    [SerializeField] float chargeTime;
    [SerializeField] int maximumCharge;
    [SerializeField] GameEvent fireEvent;
    [SerializeField] GameEvent chargeEvent;
    int charge;

    //on start and restart there is full charge
    private void OnEnable()
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
        if(charge > 0) charge--;
        fireEvent.Raise();

        StopAllCoroutines();
        StartCoroutine(Charge());
    }

    IEnumerator Charge()
    {
        yield return new WaitForSeconds(chargeTime);
        charge++;
        chargeEvent.Raise();
        if (charge < maximumCharge) StartCoroutine(Charge());
    }
}
