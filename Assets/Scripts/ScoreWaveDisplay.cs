using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreWaveDisplay : MonoBehaviour
{



    public TextMeshProUGUI scoreTextObject;
    public int scoreValue;


    //start is called before the first frame update
    private void Start()
    {
        
        
    }

    //update is called once per frame
    private void Update()
    {
        scoreValue = GameManager.Instance.GetScore();
        UpdateScoreValue();
    }

    public void UpdateScoreValue()
    {
        scoreTextObject.text = "score: " + scoreValue;
    }

}
