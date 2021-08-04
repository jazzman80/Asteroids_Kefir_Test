using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserChargeLamp : MonoBehaviour
{
    [SerializeField] GameObject uncharged;
    [SerializeField] GameObject charged;

    //on
    public void On()
    {
        uncharged.SetActive(false);
        charged.SetActive(true);
    }

    //off
    public void Off()
    {
        uncharged.SetActive(true);
        charged.SetActive(false);
    }
}
