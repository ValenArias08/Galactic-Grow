using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogerObjeto : MonoBehaviour
{
    public GameObject handPoint;
    private GameObject pickedObject = null;


private void Update() {


        if (Input.GetKeyDown(KeyCode.G))
        {
            Debug.Log("Presionando G");
        }

        if (pickedObject != null)
        {
            if (Input.GetKey("g"))
            {
                Debug.Log("Presionando G");
                pickedObject.GetComponent<Rigidbody2D>().isKinematic = false;

                pickedObject.gameObject.transform.SetParent(null);

                pickedObject = null;

            }
        }

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Objeto"))
        {
            Debug.Log("Colision objeto");
            if (Input.GetKey("g") && pickedObject == null)
            {
                other.GetComponent<Rigidbody2D>().isKinematic = true;

                other.transform.position = handPoint.transform.position;

                other.gameObject.transform.SetParent(handPoint.gameObject.transform);

                pickedObject = other.gameObject;
            }
        }
    }

}

