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
    [SerializeField] private GameObject slashUp, slashUpRight, slashUpLeft, slashDown, slashDownRight, slashDownLeft, slashRight, slashLeft;
    public bool isAttacking, isHitted;

    private Vector2 direction;

    public GameObject attackPrefab;

    private void Start()
    {
        attackPrefab.SetActive(false);

        slashDown.SetActive(false);
        slashLeft.SetActive(false);
        slashRight.SetActive(false);
        slashUp.SetActive(false);
        slashUpLeft.SetActive(false);
        slashUpRight.SetActive(false);
        slashDownLeft.SetActive(false);
        slashDownRight.SetActive(false);

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
            colliderPoints[1] = new Vector2(1.5f,0.7f);
            colliderPoints[2] = new Vector2(-0.5f, 0.7f);
            isAttacking = true;
            playerAnimator.SetBool("isAttacking", isAttacking);
            slashUp.SetActive(true);
        }

        //Ataque arriba-derecha

        /*Normalizamos las magnitudes y la comparamos con la distancia de tolerancia con el fin de que se cumpla la condicion
         aun cuando no sea exactamente 0.71f, sino un numero lo suficientemente cerca*/
        if (Mathf.Abs(direction.x - 0.71f) < toleranceDistance && Mathf.Abs(direction.y - 0.71f) < toleranceDistance)
        {
            colliderPoints[1] = new Vector2(0.9f, 0.7f);
            colliderPoints[2] = new Vector2(2.2f, -0.2f);
            attackCollider.points = colliderPoints;
            isAttacking = true;
            playerAnimator.SetBool("isAttacking", isAttacking);
            slashUpRight.SetActive(true);
        }

        //Ataque derecha
        if (direction == new Vector2(1, 0))
        {
            colliderPoints[1] = new Vector2(2.2f, 0.2f);
            colliderPoints[2] = new Vector2(2.2f, -1.2f);
            isAttacking = true;
            playerAnimator.SetBool("isAttacking", isAttacking);
            slashRight.SetActive(true);
        }

        //Ataque abajo-derecha
        if (Mathf.Abs(direction.x - 0.71f) < toleranceDistance && Mathf.Abs(direction.y + 0.71f) < toleranceDistance)
        {
            colliderPoints[1] = new Vector2(2.2f, -0.8f);
            colliderPoints[2] = new Vector2(1, -1.7f);
            isAttacking = true;
            playerAnimator.SetBool("isAttacking", isAttacking);
            slashDownRight.SetActive(true);
        }

        //Ataque abajo
        if (direction == new Vector2(0, -1))
        {
            colliderPoints[1] = new Vector2(-0.5f, -1.7f);
            colliderPoints[2] = new Vector2(1.5f, -1.7f);
            isAttacking = true;
            playerAnimator.SetBool("isAttacking", isAttacking);
            slashDown.SetActive(true);
        }

        //Ataque abajo-izquierda
        if (Mathf.Abs(direction.x + 0.71f) < toleranceDistance && Mathf.Abs(direction.y + 0.71f) < toleranceDistance)
        {
            colliderPoints[1] = new Vector2(0, -1.7f);
            colliderPoints[2] = new Vector2(-1.2f, -0.8f);
            isAttacking = true;
            playerAnimator.SetBool("isAttacking", isAttacking);
            slashDownLeft.SetActive(true);
        }

        //Ataque izquierda
        if (direction == new Vector2(-1, 0))
        {
            colliderPoints[1] = new Vector2(-1.2f, 0.2f);
            colliderPoints[2] = new Vector2(-1.2f, -1.2f);
            isAttacking = true;
            playerAnimator.SetBool("isAttacking", isAttacking);
            slashLeft.SetActive(true);
        }


        //Ataque arriba-izquierda
        if (Mathf.Abs(direction.x + 0.71f) < toleranceDistance && Mathf.Abs(direction.y - 0.71f) < toleranceDistance)
        {
            colliderPoints[1] = new Vector2(-1.2f, -0.2f);
            colliderPoints[2] = new Vector2(0, 0.7f);
            isAttacking = true;
            playerAnimator.SetBool("isAttacking", isAttacking);
            slashUpLeft.SetActive(true);
        }

        //Ataque en idle
        if (direction == new Vector2(0, 0))
        {
            colliderPoints[1] = new Vector2(2.2f, 0.2f);
            colliderPoints[2] = new Vector2(2.2f, -1.2f);
            isAttacking = true;
            playerAnimator.SetBool("isAttacking", isAttacking);
            slashRight.SetActive(true);
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

        slashDown.SetActive(false);
        slashLeft.SetActive(false);
        slashRight.SetActive(false);
        slashUp.SetActive(false);
        slashUpLeft.SetActive(false);
        slashUpRight.SetActive(false);
        slashDownLeft.SetActive(false);
        slashDownRight.SetActive(false);

        playerAnimator.SetBool("isAttacking", isAttacking);
        attackPrefab.SetActive(false);
    }
}
