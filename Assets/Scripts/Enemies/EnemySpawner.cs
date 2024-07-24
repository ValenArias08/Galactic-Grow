using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // El prefab del enemigo que queremos generar
    public GameObject enemyPrefab;

    // Puntos de spawn
    public Transform[] spawnPoints;

    // Configuración de oleadas
    public int enemiesPerWave = 10;
    public float minSpawnInterval = 1f;
    public float maxSpawnInterval = 3f;

    // Número total de enemigos por oleada
    private int totalEnemiesToSpawn;
    // Número de enemigos generados en la oleada actual
    private int spawnedEnemiesCount;

    void Start()
    {
        // Iniciar la generación de la primera oleada
        StartCoroutine(SpawnWave());
    }

    // Coroutine para generar una oleada de enemigos
    IEnumerator SpawnWave()
    {
        totalEnemiesToSpawn = enemiesPerWave;
        spawnedEnemiesCount = 0;

        while (spawnedEnemiesCount < totalEnemiesToSpawn)
        {
            // Esperar un intervalo aleatorio antes de generar más enemigos
            float spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
            yield return new WaitForSeconds(spawnInterval);

            // Elegir un número aleatorio de puntos de spawn
            int spawnPointCount = Random.Range(1, spawnPoints.Length + 1);

            // Generar enemigos en puntos de spawn aleatorios
            for (int i = 0; i < spawnPointCount && spawnedEnemiesCount < totalEnemiesToSpawn; i++)
            {
                // Elegir un punto de spawn aleatorio
                Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

                // Instanciar el enemigo en el punto de spawn
                Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);

                // Incrementar el contador de enemigos generados
                spawnedEnemiesCount++;
            }
        }

        // Iniciar la siguiente oleada después de un tiempo de descanso si es necesario
        // yield return new WaitForSeconds(waveInterval);
        // StartCoroutine(SpawnWave());
    }
}

