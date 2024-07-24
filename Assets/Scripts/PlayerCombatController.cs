using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatController : MonoBehaviour
{

    [SerializeField]private float life;
    [SerializeField] private float lifemax;
    [SerializeField] private LifeBarController lifeBar;

    // Start is called before the first frame update
    void Start()
    {
        life = lifemax;
        lifeBar.InitializerLifeBar(life);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
