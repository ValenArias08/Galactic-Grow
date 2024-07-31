using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class TopDownController : MonoBehaviour
{

    public int maxPlayerLife = 3;
    private int playerLifeCounter;

    // Character components

    public Rigidbody2D rBody;
    public InputActionReference playerInput;
    public SpriteRenderer spriteReder;

    public Image lifeCounter1;
    public Image lifeCounter2;
    public Image lifeCounter3;


    public Sprite fullHeart;
    public Sprite emptyHeart;


    public Transform attackPoint;
    // Character stats

    private float playerSpeed = 4;

    private Vector2 inputValue;
    
    
    

    public Vector2 movementInput;

    private void Action_performed(InputAction.CallbackContext obj)
    {
        throw new System.NotImplementedException();
    }

    

    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        playerLifeCounter = maxPlayerLife;
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

    public void LoseLife()
    {
        playerLifeCounter--;

        Debug.Log(playerLifeCounter);

        if (playerLifeCounter == 2)
        {
            lifeCounter3.sprite = emptyHeart;
        }

        if (playerLifeCounter == 1)
        {
            
            lifeCounter2.sprite = emptyHeart;
        }

        if (playerLifeCounter == 0)
        {
            lifeCounter1.sprite = emptyHeart;
            // AQU� M�TODO DE GAME OVER Y DESPLEGAR EL CANVAS DE REINICIAR O IR AL MEN�
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            LoseLife();
            //Debug.Log(GameManager.Instance.playerTotalScore);
        }
        
    }
}