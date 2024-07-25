using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerAhoraSi : MonoBehaviour
{   public GameObject enemyPrefab;
    [SerializeField] public int maxInstance = 10;
    [SerializeField] public float interval = 2.0f;
    private int currentInstance = 0;
    [SerializeField] private List<Vector2> spawnPos;

    // Start is called before the first frame update
    IEnumerator spawnPrefabs(){
        while(currentInstance < maxInstance){
            foreach(Vector2 position in spawnPos){
                if(currentInstance >= maxInstance)
                break;

                Instantiate(enemyPrefab, position, Quaternion.identity);

                currentInstance++;

                yield return new WaitForSeconds(interval);
            }
        }
    }
    void Start()
    {
        StartCoroutine(spawnPrefabs());
    }
    
}
