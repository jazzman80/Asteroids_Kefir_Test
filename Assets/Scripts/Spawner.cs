using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private PlayerController playerPrefab;
    [SerializeField] private UFO ufoPrefab;
    [SerializeField] private int maximumUFOCount;
    [SerializeField] private float uFOCooldownTime;
    private List<UFO> uFOPool = new List<UFO>();
    private bool needsNewUFO = true;
    [SerializeField] private Transform[] spawnPoints;

    private void Start()
    {
        PlayerController newPlayer = Instantiate(playerPrefab);

        for(int i = 0; i < maximumUFOCount; i++)
        {
            UFO newUfo = Instantiate(ufoPrefab);
            newUfo.SetTarget(newPlayer.transform);
            newUfo.gameObject.SetActive(false);
            uFOPool.Add(newUfo);
        }
    }

    private void Update()
    {
        if (needsNewUFO)
        {
            for(int i = 0; i < uFOPool.Count; i++)
            {
                if (!uFOPool[i].gameObject.activeSelf)
                {
                    ActivateUFO(i);
                    needsNewUFO = false;
                    StartCoroutine(UFOCooldown(uFOCooldownTime));
                    break;
                }
            }
        }
    }

    private void ActivateUFO(int uFOIndex)
    {
        uFOPool[uFOIndex].gameObject.SetActive(true);
        int randomPoint = Random.Range(0, spawnPoints.Length);
        uFOPool[uFOIndex].SetPosition(spawnPoints[randomPoint]);
    }

    private IEnumerator UFOCooldown(float uFOCooldownTime)
    {
        yield return new WaitForSeconds(uFOCooldownTime);
        needsNewUFO = true;
    }
}
