using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] private Ammo ammoPrefab;
    [SerializeField] private float fireForce;
    [SerializeField] private float chargeTime;
    [SerializeField] private string fireButton;

    private List<Ammo> ammoPool = new List<Ammo>();
    private bool isCharged = true;

    private void Update()
    {
        if (Input.GetButtonDown(fireButton) && isCharged)
        {
            bool isFired = false;

            for (int i = 0; i < ammoPool.Count; i++)
            {
                if (!ammoPool[i].gameObject.activeSelf)
                {
                    ammoPool[i].gameObject.SetActive(true);
                    ammoPool[i].Fire(transform, fireForce);
                    isFired = true;
                    break;
                }
            }

            if (!isFired) InstantiateAmmo();
            isCharged = false;
            StartCoroutine(Charge());
        }
    }

    private void InstantiateAmmo()
    {
        Ammo newAmmo = Instantiate(ammoPrefab);
        ammoPool.Add(newAmmo);
        newAmmo.Fire(transform, fireForce);
    }

    private IEnumerator Charge()
    {
        yield return new WaitForSeconds(chargeTime);
        isCharged = true;
    }
}
