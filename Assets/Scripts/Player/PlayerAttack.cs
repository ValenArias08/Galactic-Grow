using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{

    private bool isAttacking = false;
    private Vector2[] colliderPoints;
    public float attackCoolDown = 0.25f;
    public float attackDuration = 1f;
    public static int playerDamage = 3; 

    [SerializeField] private InputActionReference inputAttackAction;
    [SerializeField] private InputActionReference playerInput;
    [SerializeField] private PolygonCollider2D attackCollider;

    private Vector2 attackDirection;

    public GameObject attackPrefab;

    private void Start()
    {
        attackPrefab.SetActive(false);
        colliderPoints = attackCollider.points;
    }

    private void Update()
    {
        attackDirection = playerInput.action.ReadValue<Vector2>(); // Gets the input reference value for the movement method
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        Attack();
        Invoke("EndAttack", attackDuration);
        ChangePosition();
       //Debug.Log(attackDirection);
    }

    private void ChangePosition()
    {
        float toleranceDistance = 0.1f; //Cantidad que indica cuanto puede diferir

        //Ataque arriba
        if (attackDirection == new Vector2(0, 1))
        {
            colliderPoints[1] = new Vector2(1, 0.5f);
            colliderPoints[2] = new Vector2(0, 0.5f);
        }

        //Ataque arriba-derecha

        /*Normalizamos las magnitudes y la comparamos con la distancia de tolerancia con el fin de que se cumpla la condicion
         aun cuando no sea exactamente 0.71f, sino un numero lo suficientemente cerca*/
        if (Mathf.Abs(attackDirection.x - 0.71f) < toleranceDistance && Mathf.Abs(attackDirection.y - 0.71f) < toleranceDistance)
        {
            colliderPoints[1] = new Vector2(0.8f, 0.5f);
            colliderPoints[2] = new Vector2(1.5f, -0.2f);
            attackCollider.points = colliderPoints;
        }

        //Ataque derecha
        if (attackDirection == new Vector2(1, 0))
        {
            colliderPoints[1] = new Vector2(1.5f, 0);
            colliderPoints[2] = new Vector2(1.5f, -1);
        }

        //Ataque abajo-derecha
        if (Mathf.Abs(attackDirection.x - 0.71f) < toleranceDistance && Mathf.Abs(attackDirection.y + 0.71f) < toleranceDistance)
        {
            colliderPoints[1] = new Vector2(1.5f, -0.8f);
            colliderPoints[2] = new Vector2(0.8f, -1.5f);
        }

        //Ataque abajo
        if (attackDirection == new Vector2(0, -1))
        {
            colliderPoints[1] = new Vector2(0, -1.5f);
            colliderPoints[2] = new Vector2(1, -1.5f);
        }

        //Ataque abajo-izquierda
        if (Mathf.Abs(attackDirection.x + 0.71f) < toleranceDistance && Mathf.Abs(attackDirection.y + 0.71f) < toleranceDistance)
        {
            colliderPoints[1] = new Vector2(0.2f, -1.5f);
            colliderPoints[2] = new Vector2(-0.5f, -0.8f);
        }

        //Ataque izquierda
        if (attackDirection == new Vector2(-1, 0))
        {
            colliderPoints[1] = new Vector2(-0.5f, 0);
            colliderPoints[2] = new Vector2(-0.5f, -1);
        }


        //Ataque arriba-izquierda
        if (Mathf.Abs(attackDirection.x + 0.71f) < toleranceDistance && Mathf.Abs(attackDirection.y - 0.71f) < toleranceDistance)
        {
            colliderPoints[1] = new Vector2(-0.5f, -0.2f);
            colliderPoints[2] = new Vector2(0.2f, 0.5f);
        }

        //Ataque en idle
        if (attackDirection == new Vector2(0, 0))
        {
            colliderPoints[1] = new Vector2(1, -1.5f);
            colliderPoints[2] = new Vector2(0, -1.5f);
        }

        attackCollider.points = colliderPoints;

    }

    private void Attack()
    {
        isAttacking = true;
        attackPrefab.SetActive(true);
    }

    private void EndAttack()
    {
        isAttacking = false;
        attackPrefab.SetActive(false);
    }
}
