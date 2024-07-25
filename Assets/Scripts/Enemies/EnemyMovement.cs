using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float radius = 5.0f;
    private GameObject player;
    public float speed;
    public float distanceBetween; // Distance that will trigger the enemy to follow the player
    public int enemyHealth = 2; // Enemy's health
    public float knockbackForce = 5;
    public float redDuration = 0.25f;

    private SpriteRenderer spriteRenderer;
    private float distance; // Actual distance between player and enemy
    private Rigidbody2D enemyRb;
    private Color originalColor;

    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
        player = GameObject.Find("Player");
    }

    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        // Calculate distance from enemy to the player
        Vector2 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed);
    }

    public void TakeDamage(int damageOnEnemy, Vector2 knockbackDirection)
    {
        // Reduce health on damage
        enemyHealth -= damageOnEnemy;
        StartCoroutine(ChangeColorOnCollision());

        // Apply knockback force
        enemyRb.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);

        // Destroy enemy when health is less than or equal to 0
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check collision with the player
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector2 knockbackDirection = (transform.position - collision.transform.position).normalized;
            TakeDamage(1, knockbackDirection);
        }
    }

    private IEnumerator ChangeColorOnCollision()
    {
        // Change color to red
        spriteRenderer.color = Color.red;

        // Wait for the specified duration
        yield return new WaitForSeconds(redDuration);

        // Revert to the original color
        spriteRenderer.color = originalColor;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
