using UnityEngine;
using UnityEngine.InputSystem;

public class TopDownController : MonoBehaviour
{

    private int enemyDamage = 1;

    private int currentPlayerHealth;

    // Character components

    public Rigidbody2D rBody;
    public InputActionReference playerInput;
    public SpriteRenderer spriteReder;

    public Transform attackPoint;
    // Character stats

    public float playerSpeed;

    private Vector2 inputValue;
    
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    public Vector2 movementInput;

    private void Action_performed(InputAction.CallbackContext obj)
    {
        throw new System.NotImplementedException();
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        inputValue = playerInput.action.ReadValue<Vector2>(); // Gets the input reference value for the movement method


        rBody.velocity = inputValue * playerSpeed;
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        inputValue = context.ReadValue<Vector2>();
        //Debug.Log(inputValue);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GameManager.Instance.LoseLife();
            Debug.Log(GameManager.Instance.playerTotalScore);
        }
        
    }
}