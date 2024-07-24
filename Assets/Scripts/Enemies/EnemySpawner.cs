using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawnInterval = 3f;

    public int numberOfEnemies = 5;
    public float spawnX = 10;
    public float spawnY = 10;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(spawnInterval, enemyPrefab));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy){
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = 
        Instantiate(enemy, new Vector3(Random.Range(-5f, 5f), Random.Range(-5, 5), 0), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    } 
}
