using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class SideController : MonoBehaviour
{
    // Start is called before the first frame update
    // Character components

    public Rigidbody2D rBody;
    public InputActionReference playerInput;
    public SpriteRenderer spriteReder;



    // Character variables

    public float playerSpeed;
    public float fuerzaSalto;

    public bool mirandoDerecha = true;
    private Vector2 inputValue;

    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    // Getting the input reference value
    void Update()
    {
        inputValue = playerInput.action.ReadValue<Vector2>();

        AjustarRotacion(inputValue.x);
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        inputValue = context.ReadValue<Vector2>();


    }

    private void FixedUpdate()
    {
        rBody.velocity = inputValue * playerSpeed;
    }

    private void AjustarRotacion(float direccionX)
    {
        if (direccionX > 0 && !mirandoDerecha)
        {
            Girar();
        }
        else if (direccionX < 0 && mirandoDerecha)
        {
            Girar();
        }
    }
    private void Girar()
    {
        mirandoDerecha = !mirandoDerecha;
        Vector3 escala = transform.localScale;
        escala.x *= 1;
        transform.localScale = escala;
    }

    private void Saltar()
    {
        rBody.AddForce(new Vector2(0, fuerzaSalto), ForceMode2D.Impulse);
    }
}
