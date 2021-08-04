using System.Collections.Generic;
using UnityEngine;

public class Asteroid : Stone
{
    [SerializeField] List<Stone> stonePool = new List<Stone>();
    [SerializeField] Stone stonePrefab;
    [SerializeField] int stonesCount;
    Quaternion movingDirection;

    private void Start()
    {
        //create stones pool
        for(int i = 0; i < stonesCount; i++)
        {
            Stone newStone = Instantiate(stonePrefab);
            newStone.gameObject.SetActive(false);
            stonePool.Add(newStone);
        }
    }

    public override void SetRandomTrajectory()
    {
        transform.LookAt(Vector3.zero);
        float randomAngle = Random.Range(-20.0f, 20.0f);
        transform.Rotate(Vector3.up, randomAngle);
        movingDirection = transform.rotation;
    }

    //Explode to stones
    private void Explode()
    {
        foreach(Stone stone in stonePool)
        {
            stone.transform.position = transform.position;
            stone.transform.rotation = movingDirection;
            stone.gameObject.SetActive(true);
            stone.SetVisualMode(visualMode);
        }
    }

    //killed by ammo
    public override void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Ammo")) Explode();
        base.OnTriggerEnter(other);
    }

}
