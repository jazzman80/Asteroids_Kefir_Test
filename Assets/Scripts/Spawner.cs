using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private PlayerController playerPrefab;
    [SerializeField] private GameObject ufoPrefab;
    [SerializeField] private GameObject asteroidPrefab;
    [SerializeField] private Transform[] spawnPoints;

    [Header("Maximum Enemies")]
    [SerializeField] private int maximumUFOs;
    [SerializeField] private int maximumAsteroids;

    [Header("Cooldown Times")]
    [SerializeField] private float uFOCooldownTime;
    [SerializeField] private float asteroidCooldownTime;

    private List<GameObject> uFOPool = new List<GameObject>();
    private List<GameObject> asteroidsPool = new List<GameObject>();

    private bool needsUFO = true;
    private bool needsAsteroid = true;

    private void Start()
    {
        PlayerController newPlayer = Instantiate(playerPrefab);

        CreatePool(ufoPrefab, maximumUFOs, uFOPool);
        CreatePool(asteroidPrefab, maximumAsteroids, asteroidsPool);

        SetTargets(uFOPool, newPlayer.transform);
    }

    private void Update()
    {
        if (needsUFO) ActivateEnemy(uFOPool, needsUFO, uFOCooldownTime);
        if (needsAsteroid) ActivateEnemy(asteroidsPool, needsAsteroid, asteroidCooldownTime);
    }

    private void CreatePool(GameObject enemy, int maximumEnemies, List<GameObject> pool)
    {
        for (int i = 0; i < maximumEnemies; i++)
        {
            GameObject newEnemy = Instantiate(enemy);
            newEnemy.gameObject.SetActive(false);
            pool.Add(newEnemy);
        }
    }

    private void SetTargets(List<GameObject> pool, Transform target)
    {
        for(int i = 0; i < pool.Count; i++)
        {
            UFO newUFO = pool[i].GetComponent<UFO>();
            newUFO.SetTarget(target);
        }
    }

    private void ActivateEnemy(List<GameObject> pool, bool needsEnemy, float cooldownTime)
    {
        for (int i = 0; i < pool.Count; i++)
        {
            if (!pool[i].gameObject.activeSelf)
            {
                pool[i].gameObject.SetActive(true);
                int randomPoint = Random.Range(0, spawnPoints.Length);
                pool[i].transform.position = spawnPoints[randomPoint].position;
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
