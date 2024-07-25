using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefab del enemigo
    public Transform[] spawnPoints; // Puntos de spawn donde los enemigos aparecerán
    public int maxEnemiesPerWave = 10; // Número máximo de enemigos por oleada
    public float spawnIntervalMin = 1f; // Intervalo mínimo de tiempo entre spawns
    public float spawnIntervalMax = 3f; // Intervalo máximo de tiempo entre spawns
    public float waveInterval = 10f; // Tiempo entre oleadas

    private int currentWave = 0; // Contador de la oleada actual
    private int enemiesSpawned = 0; // Contador de enemigos spawneados en la oleada actual
    private int enemiesDestroyed = 0; // Contador de enemigos destruidos en la oleada actual

    void Start()
    {
        StartCoroutine(SpawnWave());
    }

    private IEnumerator SpawnWave()
    {
        while (true)
        {
            currentWave++;
            enemiesSpawned = 0;
            enemiesDestroyed = 0;

            int enemiesToSpawn = maxEnemiesPerWave;
            List<Transform> availableSpawnPoints = new List<Transform>(spawnPoints);

            while (enemiesToSpawn > 0)
            {
                int spawnIndex = Random.Range(0, availableSpawnPoints.Count);
                Transform spawnPoint = availableSpawnPoints[spawnIndex];
                Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
                enemiesSpawned++;
                enemiesToSpawn--;

                // Esperar un intervalo aleatorio antes de spawnear el próximo enemigo
                float spawnInterval = Random.Range(spawnIntervalMin, spawnIntervalMax);
                yield return new WaitForSeconds(spawnInterval);

                // Eliminar el punto de spawn utilizado para evitar reutilizarlo en la misma oleada
                availableSpawnPoints.RemoveAt(spawnIndex);

                // Si no quedan puntos de spawn, restablecer la lista
                if (availableSpawnPoints.Count == 0)
                {
                    availableSpawnPoints = new List<Transform>(spawnPoints);
                }
            }

            // Esperar el intervalo de la oleada antes de comenzar la siguiente oleada
            yield return new WaitForSeconds(waveInterval);
        }
    }

    public void EnemyDestroyed()
    {
        enemiesDestroyed++;
        if (enemiesDestroyed >= maxEnemiesPerWave)
        {
            // Todos los enemigos en la oleada actual han sido destruidos
            Debug.Log("Wave " + currentWave + " completed!");
        }
    }
}