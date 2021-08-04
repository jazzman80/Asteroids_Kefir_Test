using UnityEngine;

public class LaserChargeIndicator : MonoBehaviour
{
    [SerializeField] LaserChargeLamp[] laserLamps;
    int ammosCount;

    //on start and restart there is full charge
    public void OnEnable()
    {
        ammosCount = 2;
        foreach (LaserChargeLamp lamp in laserLamps) lamp.On();
    }

    public void OnFire()
    {
        laserLamps[ammosCount].Off();
        ammosCount--;
    }

    public void OnCharge()
    {
        ammosCount++;
        laserLamps[ammosCount].On();
    }
}
