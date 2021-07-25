using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private PlayerController playerPrefab;
    [SerializeField] private UFO ufoPrefab;
    [SerializeField] private Asteroid asteroidPrefab;
    [SerializeField] private Transform[] spawnPoints;

    [Header("Maximum Enemies")]
    [SerializeField] private int maximumUFOs;
    [SerializeField] private int maximumAsteroids;

    [Header("Cooldown Times")]
    [SerializeField] private float uFOCooldownTime;
    [SerializeField] private float asteroidCooldownTime;

    private List<Enemy> uFOPool = new List<Enemy>();
    private List<Enemy> asteroidsPool = new List<Enemy>();
    private EnemyPool uFOsPool;

    private bool needsUFO = true;
    private bool needsAsteroid = true;

    private void Start()
    {
        PlayerController newPlayer = Instantiate(playerPrefab);

        uFOsPool.SetData(ufoPrefab, maximumUFOs);


        CreatePool(ufoPrefab, maximumUFOs, uFOPool);
        CreatePool(asteroidPrefab, maximumAsteroids, asteroidsPool);

        SetTargets(uFOPool, newPlayer.transform);
    }

    private void Update()
    {
        if (needsUFO) ActivateEnemy(uFOPool, out needsUFO, uFOCooldownTime);
        //if (needsAsteroid) ActivateEnemy(asteroidsPool, needsAsteroid, asteroidCooldownTime);
    }

    private void CreatePool(Enemy prefab, int maximumEnemies, List<Enemy> pool)
    {
        for (int i = 0; i < maximumEnemies; i++)
        {
            Enemy newEnemy = Instantiate(prefab);
            newEnemy.gameObject.SetActive(false);
            pool.Add(prefab);
        }
    }

    private void SetTargets(List<Enemy> pool, Transform target)
    {
        for(int i = 0; i < pool.Count; i++)
        {
            pool[i].SetTarget(target);
        }
    }

    private void ActivateEnemy(List<Enemy> pool, out bool needsEnemy, float cooldownTime)
    {
        needsEnemy = true;

        for (int i = 0; i < pool.Count; i++)
        {
            if (!pool[i].gameObject.activeSelf)
            {
                pool[i].gameObject.SetActive(true);
                int randomPoint = Random.Range(0, spawnPoints.Length);
                pool[i].SetPosition(spawnPoints[randomPoint]);
                needsEnemy = false;
                StartCoroutine(Cooldown(needsEnemy, cooldownTime));
                break;
            }
        }

    }

    private IEnumerator Cooldown(bool needsEnemy, float cooldownTime)
    {
        yield return new WaitForSeconds(cooldownTime);
        needsEnemy = true;
    }
}
