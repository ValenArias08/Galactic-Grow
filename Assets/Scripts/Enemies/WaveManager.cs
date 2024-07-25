using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public int currentWave = 0;
    public int enemiesPerWave = 10;
    public int spawnedEnemiesCount = 0;
    public int killedEnemiesCount = 0;
    public float minSpawnInterval = 1f;
    public float maxSpawnInterval = 3f;

    public Transform[] spawnPoints;
    public GameObject enemyPrefab;

    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        StartNextWave();
    }

    void StartNextWave()
    {
        currentWave++;
        spawnedEnemiesCount = 0;
        killedEnemiesCount = 0;

        StartCoroutine(SpawnWave());
    }

    IEnumerator SpawnWave()
    {
        while (spawnedEnemiesCount < enemiesPerWave)
        {
            float spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
            yield return new WaitForSeconds(spawnInterval);

            int spawnPointIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[spawnPointIndex];

            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            spawnedEnemiesCount++;
        }
    }

    public void EnemyKilled()
    {
        killedEnemiesCount++;
        if (killedEnemiesCount >= enemiesPerWave)
        {
            EndWave();
        }
    }

    void EndWave()
    {
        int scoreForWave = killedEnemiesCount * 10; // Por ejemplo, 10 puntos por enemigo
        gameManager.AddScore(scoreForWave);
        StartNextWave();
    }
}
