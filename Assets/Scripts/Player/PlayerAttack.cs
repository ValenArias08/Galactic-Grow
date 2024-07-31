using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{

    private Vector2[] colliderPoints;
    public float attackCoolDown = 0.25f;
    public float attackDuration = 1f;
    public static int playerDamage = 3; 

    [SerializeField] private InputActionReference inputAttackAction;
    [SerializeField] private InputActionReference playerInput;
    [SerializeField] private PolygonCollider2D attackCollider;

    //Animations
    [SerializeField] private Animator playerAnimator;
    public bool isAttacking, isHitted;

    private Vector2 direction;

    public GameObject attackPrefab;

    private void Start()
    {
        attackPrefab.SetActive(false);
        colliderPoints = attackCollider.points;
    }

    private void Update()
    {
        direction = playerInput.action.ReadValue<Vector2>();

        // Comprobar la direccion del jugador

        if (direction != Vector2.zero)
        {
            if (direction.x > 0) // Right
            {
                playerAnimator.SetBool("isMoveUp", false);
                playerAnimator.SetBool("isMoveDown", false);
                playerAnimator.SetBool("isMoveLeft", false);
                playerAnimator.SetBool("isMoveRight", true);
            }
            
            if (direction.x < 0) // Left
            {
                playerAnimator.SetBool("isMoveUp", false);
                playerAnimator.SetBool("isMoveDown", false);
                playerAnimator.SetBool("isMoveRight", false);
                playerAnimator.SetBool("isMoveLeft", true);
            }

            if (direction.y > 0) // Up
            {
                playerAnimator.SetBool("isMoveRight", false);
                playerAnimator.SetBool("isMoveLeft", false);
                playerAnimator.SetBool("isMoveDown", false);
                playerAnimator.SetBool("isMoveUp", true);
            }
            
            if (direction.y < 0) // Down
            {
                playerAnimator.SetBool("isMoveRight", false);
                playerAnimator.SetBool("isMoveLeft", false);
                playerAnimator.SetBool("isMoveUp", false);
                playerAnimator.SetBool("isMoveDown", true);
            }
        }
        else
        {
            playerAnimator.SetBool("isMoveRight", false);
            playerAnimator.SetBool("isMoveLeft", false);
            playerAnimator.SetBool("isMoveUp", false);
            playerAnimator.SetBool("isMoveDown", false);
        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        Attack();
        ChangePosition();
        Invoke("EndAttack", attackDuration);
        //Debug.Log(attackDirection);
    }

    private void ChangePosition()
    {
        float toleranceDistance = 0.1f; //Cantidad que indica cuanto puede diferir

        //Ataque arriba
        if (direction == new Vector2(0, 1))
        {
            colliderPoints[1] = new Vector2(1, 0.5f);
            colliderPoints[2] = new Vector2(0, 0.5f);
            isAttacking = true;
            playerAnimator.SetBool("isAttacking", isAttacking);
        }

        //Ataque arriba-derecha

        /*Normalizamos las magnitudes y la comparamos con la distancia de tolerancia con el fin de que se cumpla la condicion
         aun cuando no sea exactamente 0.71f, sino un numero lo suficientemente cerca*/
        if (Mathf.Abs(direction.x - 0.71f) < toleranceDistance && Mathf.Abs(direction.y - 0.71f) < toleranceDistance)
        {
            colliderPoints[1] = new Vector2(0.8f, 0.5f);
            colliderPoints[2] = new Vector2(1.5f, -0.2f);
            attackCollider.points = colliderPoints;
            isAttacking = true;
            playerAnimator.SetBool("isAttacking", isAttacking);
        }

        //Ataque derecha
        if (direction == new Vector2(1, 0))
        {
            colliderPoints[1] = new Vector2(1.5f, 0);
            colliderPoints[2] = new Vector2(1.5f, -1);
            isAttacking = true;
            playerAnimator.SetBool("isAttacking", isAttacking);
        }

        //Ataque abajo-derecha
        if (Mathf.Abs(direction.x - 0.71f) < toleranceDistance && Mathf.Abs(direction.y + 0.71f) < toleranceDistance)
        {
            colliderPoints[1] = new Vector2(1.5f, -0.8f);
            colliderPoints[2] = new Vector2(0.8f, -1.5f);
            isAttacking = true;
            playerAnimator.SetBool("isAttacking", isAttacking);
        }

        //Ataque abajo
        if (direction == new Vector2(0, -1))
        {
            colliderPoints[1] = new Vector2(0, -1.5f);
            colliderPoints[2] = new Vector2(1, -1.5f);
            isAttacking = true;
            playerAnimator.SetBool("isAttacking", isAttacking);
        }

        //Ataque abajo-izquierda
        if (Mathf.Abs(direction.x + 0.71f) < toleranceDistance && Mathf.Abs(direction.y + 0.71f) < toleranceDistance)
        {
            colliderPoints[1] = new Vector2(0.2f, -1.5f);
            colliderPoints[2] = new Vector2(-0.5f, -0.8f);
            isAttacking = true;
            playerAnimator.SetBool("isAttacking", isAttacking);
        }

        //Ataque izquierda
        if (direction == new Vector2(-1, 0))
        {
            colliderPoints[1] = new Vector2(-0.5f, 0);
            colliderPoints[2] = new Vector2(-0.5f, -1);
            isAttacking = true;
            playerAnimator.SetBool("isAttacking", isAttacking);
        }


        //Ataque arriba-izquierda
        if (Mathf.Abs(direction.x + 0.71f) < toleranceDistance && Mathf.Abs(direction.y - 0.71f) < toleranceDistance)
        {
            colliderPoints[1] = new Vector2(-0.5f, -0.2f);
            colliderPoints[2] = new Vector2(0.2f, 0.5f);
            isAttacking = true;
            playerAnimator.SetBool("isAttacking", isAttacking);
        }

        //Ataque en idle
        if (direction == new Vector2(0, 0))
        {
            colliderPoints[1] = new Vector2(1, -1.5f);
            colliderPoints[2] = new Vector2(0, -1.5f);
            isAttacking = true;
            playerAnimator.SetBool("isAttacking", isAttacking);
        }

        attackCollider.points = colliderPoints;

    }

    private void Attack()
    {
        attackPrefab.SetActive(true);
    }

    private void EndAttack()
    {
        isAttacking = false;
        playerAnimator.SetBool("isAttacking", isAttacking);
        attackPrefab.SetActive(false);
    }
}
