using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public GameObject player;
    public float speed;
    public float distanceBetween; //Distance that will trigger the enemy to follow the player
    public int health = 2; // Enemy's health

    public float knockbackForce = 5;
    public float redDuration = 0.25f;

    private SpriteRenderer spriteRenderer;

    private float distance; //Actual distance between player and enemy

    private Rigidbody2D enemyRb;
    private Color originalColor;


    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();

        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;

    }

    // Update is called once per frame
    void Update()
    {
        //calculate distance from enemy to the player
        distance = Vector2.Distance(transform.position, player.transform.position); 
        
        Vector2 direction = player.transform.position - transform.position.normalized;
        //angle of rotation
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //Condition to make the enemy move towards the player while facing him
        if(distance < distanceBetween){
        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }

        
    }
    //Method for the enemy to take damage
    public void TakeDamage(int damage, Vector2 knockbackDirection){

        //reduce health on damage
        health -= damage;
        StartCoroutine(ChangeColorOnCollision());

    //apply knockback force
    enemyRb.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);


        //destroy enemy when health is less than 0
        if(health <= 0) {
            Destroy(gameObject);
        }
    }
    //Method to increment damage on health when enemy is Collided
    void OnCollisionEnter2D(Collision2D collision) {
        //call a collision with the tag Player
        if(collision.gameObject.tag == "Player"){
            //Collision will make 1 int damage & and rest the collision position to the enemy position
            Vector2 knockbackDirection = (transform.position - collision.transform.position).normalized;
            TakeDamage(1, knockbackDirection);
        }

        
    }

        // Coroutine to change color and then revert back
    private IEnumerator ChangeColorOnCollision()
    {
        // Change color to red
        spriteRenderer.color = Color.red;

        // Wait for the specified duration
        yield return new WaitForSeconds(redDuration);

        // Revert to the original color
        spriteRenderer.color = originalColor;
;
    }
}
