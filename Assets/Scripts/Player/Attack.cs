using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float attackSpeed = 5f;
    private Vector3 direction;
    private GameObject player;

    public void Initialize(Vector3 direction, GameObject player)
    {
        this.direction = direction;
        this.player = player;
        Destroy(gameObject, 2f);
    }

    private void Update()
    {
        transform.position += direction * attackSpeed * Time.deltaTime;
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            EnemyMovement.TakeDamage(1, );
            GameManager.Instance.AddScore(10);
            Destroy(gameObject);
        }
    }*/
}
