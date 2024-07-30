using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float radius = 5.0f;
    private GameObject player;
    public float speed;
    public float distanceBetween; // Distance that will trigger the enemy to follow the player
    public int enemyHealth = 10; // Enemy's health
    private int enemyScorePoints = 15;
    public float knockbackForce = 5;
    public float redDuration = 0.25f;

    private SpriteRenderer spriteRenderer;
    private float distance; // Distance between player and enemy
    private Rigidbody2D enemyRb;
    private Color originalColor;

    private int incomingDamage;

    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
        player = GameObject.Find("Player");
        incomingDamage = PlayerAttack.playerDamage;
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

    public void TakeDamage(int incomingDamage, Vector2 knockbackDirection)
    {
        // Reduce health on damage

        enemyHealth = enemyHealth - incomingDamage;
        StartCoroutine(ChangeColorOnCollision());

        // Apply knockback force
        enemyRb.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);

        // Destroy enemy when health is less than or equal to 0

        if (enemyHealth <= 0 && GameManager.Instance != null)
        {
            GameManager.Instance.AddScore(enemyScorePoints);
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check collision with the player
        if (collision.gameObject.CompareTag("AttackCollision"))
        {
            Vector2 knockbackDirection = (transform.position - collision.transform.position).normalized;
            TakeDamage(incomingDamage, knockbackDirection);
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
