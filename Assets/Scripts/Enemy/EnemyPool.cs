using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    private Enemy prefab;
    private List<Enemy> pool = new List<Enemy>();
    private bool needsEnemy = true;
    private int maximumEnemies;

    public void SetData(Enemy prefab, int maximumEnemies)
    {
        this.prefab = prefab;
        this.maximumEnemies = maximumEnemies;

        CreatePool();
    }
    
    private void CreatePool()
    {
        for (int i = 0; i < maximumEnemies; i++)
        {
            Enemy newEnemy = Instantiate(prefab);
            newEnemy.gameObject.SetActive(false);
            pool.Add(prefab);
        }
    }

    public void Activate()
    {

    }


}
