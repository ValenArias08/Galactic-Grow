using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerAhoraSi : MonoBehaviour
{   public GameObject enemyPrefab;
    private float interval01;
    private float interval02;
    private float interval03;
    
    //private int currentInstance = 0;
    [SerializeField] private List<Vector2> spawnCerca;
    [SerializeField] private List<Vector2> spawnMedio;
    [SerializeField] private List<Vector2> spawnLejos;

    private WaveManager waveManager;

    private void Awake()
    {
        waveManager = FindObjectOfType<WaveManager>();
        if (waveManager == null)
        {
            Debug.LogError("WaveManager no encontrado en la escena.");
        }
    }

    private void Start()
    {
        
    }

    public void StartNextWave()
    {
        //currentInstance = 0;
        StopAllCoroutines();
        StartCoroutine(spawnPrefabsCerca());
        StartCoroutine(spawnPrefabsMedio());
        StartCoroutine(spawnPrefabsLejos());
    }

    // Start is called before the first frame update
    IEnumerator spawnPrefabsCerca(){
        while (waveManager.spawnedEnemiesCount < waveManager.enemiesPerWave)
        {
            foreach (Vector2 position in spawnCerca)
            {
                if (waveManager.spawnedEnemiesCount >= waveManager.enemiesPerWave)
                    break;

                Instantiate(enemyPrefab, position, Quaternion.identity);
                waveManager.IncrementSpawnedEnemies();

                interval01 = Random.Range(6.0f, 8.0f);
                yield return new WaitForSeconds(interval01);
            }
        }
    }

    IEnumerator spawnPrefabsMedio()
    {
        while (waveManager.spawnedEnemiesCount < waveManager.enemiesPerWave)
        {
            foreach (Vector2 position in spawnMedio)
            {
                if (waveManager.spawnedEnemiesCount >= waveManager.enemiesPerWave)
                    break;

                Instantiate(enemyPrefab, position, Quaternion.identity);
                waveManager.IncrementSpawnedEnemies();

                interval02 = Random.Range(4.0f, 5.0f);
                yield return new WaitForSeconds(interval02);
            }
        }
    }

    IEnumerator spawnPrefabsLejos()
    {
        while (waveManager.spawnedEnemiesCount < waveManager.enemiesPerWave)
        {
            foreach (Vector2 position in spawnLejos)
            {
                if (waveManager.spawnedEnemiesCount >= waveManager.enemiesPerWave)
                    break;

                Instantiate(enemyPrefab, position, Quaternion.identity);
                waveManager.IncrementSpawnedEnemies();

                interval03 = Random.Range(1.5f, 3.0f);
                yield return new WaitForSeconds(interval03);
            }
        }
    }
    
}
