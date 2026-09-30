using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public GameObject gate;
    public int enemyCount = 10;
    public float spawnDelay = 5f;

    List<GameObject> enemies = new List<GameObject>();

    void Start()
    {
        StartCoroutine(SpawnEnemyLoop());
    }

    IEnumerator SpawnEnemyLoop()
    {
        // Spawn 10 enemies, one every 5 seconds
        for (int i = 0; i < enemyCount; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnDelay);
        }

        // Wait until every enemy is dead
        while (enemies.Exists(e => e != null))
        {
            yield return null; // wait one frame, then check again
        }

        // Open the gate
        gate.SetActive(false);
    }

    void SpawnEnemy()
    {
        int index = Random.Range(0, enemyPrefabs.Length);
        GameObject enemy = Instantiate(enemyPrefabs[index], transform.position, transform.rotation);
        enemies.Add(enemy);
    }
}