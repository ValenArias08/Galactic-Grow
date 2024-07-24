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

    // Character variables

    public float playerSpeed;
    private Vector2 inputValue;

    public float playerLifeCount = 3;

    // Attak stats

    public float attackRange = 1.0f;
    public float attackDamage = 10;

    // Enemy

    private 

    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();      
    }

    // Getting the input reference value
    void Update()
    {
        inputValue = playerInput.action.ReadValue<Vector2>();
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        inputValue = context.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        rBody.velocity = inputValue * playerSpeed;
    }

}