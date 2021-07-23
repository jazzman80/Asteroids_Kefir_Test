using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private PlayerController playerPrefab;
    [SerializeField] private UFO ufoPrefab;
    [SerializeField] private Transform[] spawnPoints;

    private void Start()
    {
        PlayerController newPlayer = Instantiate(playerPrefab);
        UFO newUfo = Instantiate(ufoPrefab);
        newUfo.SetData(spawnPoints[Random.Range(0, spawnPoints.Length)], newPlayer.transform);
    }
}
