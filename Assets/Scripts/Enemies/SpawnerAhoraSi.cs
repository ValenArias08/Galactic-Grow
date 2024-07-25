using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerAhoraSi : MonoBehaviour
{   public GameObject enemyPrefab;
    [SerializeField] public int maxInstance = 10;
    private float interval01;
    private float interval02;
    private float interval03;
    
    private int currentInstance = 0;
    [SerializeField] private List<Vector2> spawnCerca;
    [SerializeField] private List<Vector2> spawnMedio;
    [SerializeField] private List<Vector2> spawnLejos;

    // Start is called before the first frame update
    IEnumerator spawnPrefabsCerca(){
        while(currentInstance < maxInstance){
            foreach(Vector2 position in spawnCerca){
                if(currentInstance >= maxInstance)
                break;

                Instantiate(enemyPrefab, position, Quaternion.identity);

                currentInstance++;

                interval01 = Random.Range(1.0f, 2.0f);
                yield return new WaitForSeconds(interval01);
            }
        }
    }

    IEnumerator spawnPrefabsMedio()
    {
        while (currentInstance < maxInstance)
        {
            foreach (Vector2 position in spawnMedio)
            {
                if (currentInstance >= maxInstance)
                    break;

                Instantiate(enemyPrefab, position, Quaternion.identity);

                currentInstance++;

                interval02 = Random.Range(1.5f, 3.0f);
                yield return new WaitForSeconds(interval02);
            }
        }
    }

    IEnumerator spawnPrefabsLejos()
    {
        while (currentInstance < maxInstance)
        {
            foreach (Vector2 position in spawnLejos)
            {
                if (currentInstance >= maxInstance)
                    break;

                Instantiate(enemyPrefab, position, Quaternion.identity);

                currentInstance++;

                interval03 = Random.Range(2.5f, 5.0f);
                yield return new WaitForSeconds(interval02);
            }
        }
    }

    void Start()
    {
        StartCoroutine(spawnPrefabsCerca());
        StartCoroutine(spawnPrefabsMedio());
        StartCoroutine(spawnPrefabsLejos());
    }
    
}
