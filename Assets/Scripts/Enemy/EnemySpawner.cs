using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float time = 2.5f;
    public GameObject playerPrefab;
    //public GameObject[] Enemies;
    public Transform[] spawnEnemiesLocations;

    private void Start()
    {
        //Vector2 spawnPos = spawnEnemiesLocations[Random.Range(0, spawnEnemiesLocations.Length)].position;
        StartCoroutine(SpawnEnemies());
    }
    IEnumerator SpawnEnemies()
    {
        Vector2 spawnPos = spawnEnemiesLocations[Random.Range(0, spawnEnemiesLocations.Length)].position;
        Instantiate(playerPrefab, spawnPos, Quaternion.identity);
        yield return new WaitForSeconds(time);
        StartCoroutine(SpawnEnemies());
    }
}
