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
    private float timer = 0f; 

    [SerializeField] private InputActionReference inputAttackAction;
    [SerializeField] private InputActionReference playerInput;
    [SerializeField] private PolygonCollider2D attackCollider; 

    public GameObject attackPrefab;

    private void Start()
    {
        attackPrefab.SetActive(false);
        colliderPoints = attackCollider.points;
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        Attack();
        Invoke("EndAttack", attackDuration);
        

    }

    private void ChangePosition( Vector2 point1, Vector2 point2)
    {
        colliderPoints[1] = point1;
        colliderPoints[1] = point2;
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
