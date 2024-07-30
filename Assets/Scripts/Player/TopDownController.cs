using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TopDownController : MonoBehaviour
{
    
    
    
    // Character components

    public Rigidbody2D rBody;
    public InputActionReference playerInput;
    public SpriteRenderer spriteReder;
    public InputActionReference inputMovementAction;

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
    }

}