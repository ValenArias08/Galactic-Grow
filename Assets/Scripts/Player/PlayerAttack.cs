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
        ChangePosition();
    }

    private void ChangePosition()
    {
        for (int i = 0; i < colliderPoints.Length; i++)
        {
            Debug.Log(colliderPoints[i]);
        }
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
