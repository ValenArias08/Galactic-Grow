using UnityEngine;
using UnityEngine.InputSystem;

public class SideController : MonoBehaviour
{
    // Start is called before the first frame update
    // Character components



    public Rigidbody2D rBody;
    public InputActionReference playerInput;
    public SpriteRenderer spriteReder;
    public PlayerInput playerInput1;



    // Character variables

    public float playerSpeed;
    public float fuerzaSalto;

    public bool mirandoDerecha = true;
    private Vector2 inputValue;


    //Animations
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private bool isMoveRight, isMoveLeft;

    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    // Getting the input reference value
    void Update()
    {
        inputValue = playerInput1.actions["SideMove"].ReadValue<Vector2>();


        // Comprobar la dirección del movimiento basado en el input
        if (inputValue.x > 0)
        {
            isMoveRight = true;
            playerAnimator.SetBool("isMoveRight", isMoveRight);
        }
        else if (inputValue.x < 0)
        {
            isMoveLeft = true;
            playerAnimator.SetBool("isMoveLeft", isMoveLeft);
        }
        else
        {
            isMoveLeft = false;
            playerAnimator.SetBool("isMoveLeft", isMoveLeft);
            isMoveRight = false;
            playerAnimator.SetBool("isMoveRight", isMoveRight);
            
        }


        AjustarRotacion(inputValue.x);
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
