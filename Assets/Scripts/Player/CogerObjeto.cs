using UnityEngine;
using UnityEngine.InputSystem;

public class CogerObjeto : MonoBehaviour
{
    public GameObject handPoint;
    public bool isHandObject;
    public bool canGrab;
    private GameObject pickedObject = null;

    public InputActionReference playerInput;


    private void Start()
    {
        isHandObject = false;

        playerInput.action.performed += Grab;
        playerInput.action.canceled += Grab;
    }

    private void OnDestroy()
    {
        playerInput.action.performed -= Grab;
        playerInput.action.canceled -= Grab;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Objeto") && pickedObject == null)
        {   
            Canvas actionCanvas = other.gameObject.GetComponentInChildren<Canvas>();

            if (playerInput.action.IsPressed())
            {   
                if(actionCanvas != null)
                {
                    actionCanvas.gameObject.SetActive(false); 
                }

                other.GetComponent<Rigidbody2D>().isKinematic = true;
                other.transform.position = handPoint.transform.position;
                other.gameObject.transform.SetParent(handPoint.transform);
                pickedObject = other.gameObject;
            }
        }
    }


    public void Grab(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Presionando G");
        }
        else if (context.canceled)
        {
            Debug.Log("Soltando G");
            if (pickedObject != null)
            {
                pickedObject.GetComponent<Rigidbody2D>().isKinematic = false;
                pickedObject.transform.SetParent(null);
                pickedObject = null;
            }
        }
    }

}

