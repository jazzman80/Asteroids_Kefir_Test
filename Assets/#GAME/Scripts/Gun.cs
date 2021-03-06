using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class Gun : MonoBehaviour
{
    [SerializeField] Ammo ammo;
    [SerializeField] protected float fireForce;
    [SerializeField] protected string fireButton;
    [SerializeField] protected StudioEventEmitter shootSound;
    protected bool isGameRunning = false;

    List<Ammo> ammoPool = new List<Ammo>();

    private void Update()
    {
        //fires on fire conditions
        if (CheckFire())
        {
            bool isFired = false;

            //find fist inactive ammo and fires
            foreach (Ammo ammo in ammoPool)
            {
                if (!ammo.gameObject.activeSelf)
                {
                    ammo.gameObject.SetActive(true);
                    Fire(ammo);
                    isFired = true;

                    break;
                }
            }

            //if no inactive ammo here - instantiate new one and fires
            if(!isFired)
            {
                Ammo newAmmo = Instantiate(ammo);
                ammoPool.Add(newAmmo);
                Fire(newAmmo);
            }
        }

    }

    //fires if fire button down
    public virtual bool CheckFire()
    {
        if (Input.GetButtonDown(fireButton) && isGameRunning) return true;
        else return false;
    }
    
    public virtual void Fire(Ammo ammo)
    {
        ammo.Fire(transform, fireForce);
        shootSound.Play();
    }

    //on game start
    public void OnGameStart()
    {
        isGameRunning = true;
    }
}
