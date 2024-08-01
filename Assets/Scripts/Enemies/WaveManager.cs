using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public int currentWave = 0; // Oleada actual
    public int enemiesPlusPerWave = 5; // El numero de enemigos que se suma cada oleada
    public int baseEnemiesPerWave = 5; // El numero de enemigos base, de la primera oleada
    public int maxEnemiesPerWave = 30; // Maximo numero de enemigps
    public int enemiesPerWave;         // Los enemigos por oleada. Esta sigue el numero de enemigos que se van a spawnear esa oleada
    public int spawnedEnemiesCount = 0;  // Enemigos actuales
    public int killedEnemiesCount = 0;  // Enemigos derrotados

    private SpawnerAhoraSi spawner;

    void Start()
    {
        spawner = FindObjectOfType<SpawnerAhoraSi>();
        if (spawner == null)
        {
            Debug.LogError("SpawnerAhoraSi no encontrado en la escena.");
        }
        StartNextWave();
    }

    //Comenzar una nueva oleada
    void StartNextWave()
    {
        currentWave++;
        // Reinicia el conteo de enemigos generados
        spawnedEnemiesCount = 0;
        // Reinicia el conteo de enemigos eliminados
        killedEnemiesCount = 0;

        //Aqui va el codigo que se encarga de aumentar un numero n de enemigos por oleada
        enemiesPerWave = Mathf.Min(baseEnemiesPerWave + (currentWave - 1) * enemiesPlusPerWave, maxEnemiesPerWave);
        if (spawner != null)
        {
            spawner.StartNextWave();
        }
    }

    public void IncrementSpawnedEnemies()
    {
        spawnedEnemiesCount++;
    }

    //Metodo de eliminar enemigo
    public void EnemyKilled()
    {
        killedEnemiesCount++;
        if (killedEnemiesCount >= enemiesPerWave)
        {
            EndWave(); // Termina la oleada si se han eliminado suficientes enemigos
        }
    }

    // Finaliza la oleada actual y prepara la siguiente
    void EndWave()
    {   
        // Aqui se puede manejar todo lo relacionado al terminar una oleada
        Debug.Log("Oleada terminada");

        //Iniciar la siguiente oleada
        // Se podria usar un Invoke para ponerle un tiempo de espera. Algo asi:
        //Invoke("StartNextWave", 5f");

        StartNextWave();
    }

}
