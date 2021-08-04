using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] Enemy enemy;
    [SerializeField] float maximumEnemies;
    [SerializeField] float cooldownTime;
    [SerializeField] Transform[] spawnPoints;

    public bool isGameRunning = false;

    List<Enemy> enemyPool = new List<Enemy>();
    bool isNeedEnemy = true;

    private void Start()
    {
        //build enemy pool
        for(int i = 0; i < maximumEnemies; i++)
        {
            Enemy newEnemy = Instantiate(enemy);
            newEnemy.gameObject.SetActive(false);
            enemyPool.Add(newEnemy);
        }
    }

    private void Update()
    {
        //activate enemy if cooldown time is over 
        //if the game is running
        if (isNeedEnemy && isGameRunning)
        {
            foreach(Enemy enemy in enemyPool)
            {
                if (!enemy.gameObject.activeSelf)
                {

                    //set enemy at random spawn point
                    int randomPointIndex = Random.Range(0, spawnPoints.Length);
                    Transform randomPoint = spawnPoints[randomPointIndex];
                    enemy.gameObject.transform.position = randomPoint.position;
                    enemy.gameObject.SetActive(true);

                    isNeedEnemy = false;
                    StartCoroutine(Cooldown());

                    break;
                }
            }
        }
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(cooldownTime);
        isNeedEnemy = true;
    }

    //on visual mode change
    public void ChangeVisualMode(int mode)
    {
        foreach (Enemy enemy in enemyPool)
        {
            enemy.visualMode = mode;
            enemy.SetVisualMode(mode);
        }
    }

    //on game start
    public void OnStart(int mode)
    {
        isGameRunning = true;
        ChangeVisualMode(mode);
    }

    //on game over
    public void OnGameOver()
    {
        isGameRunning = false;
        foreach (Enemy enemy in enemyPool) enemy.gameObject.SetActive(false);
    }

    //on restart
    public void OnRestart()
    {
        isGameRunning = true;
    }
}
