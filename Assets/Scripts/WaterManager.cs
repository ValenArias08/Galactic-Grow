using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterManager : MonoBehaviour
{
    [SerializeField] GameObject water;
    void Start()
    {
        // Si existe un estado de planta guardado en el GameManager, úsalo
        if (GameManager.Instance.night != 0)
        {
            ActivateWater();
        }
        else
        {
            gameObject.SetActive(false);
        }

    }

    public void ActivateWater()
    {
        if (water != null)
        {
            water.SetActive(true);
            water.transform.position = new Vector3(-25, -70, 0);
        }
    }
}
