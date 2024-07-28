using UnityEngine;
using UnityEngine.InputSystem;

public class HouseTrigger : MonoBehaviour
{
    public InputActionReference interactActionReference;

    private void Update()
    {
        if (interactActionReference!=null && interactActionReference.action.triggered)
        {
            GameManager.Instance.LoadScene("NightScene");
        }
    }

    
}
