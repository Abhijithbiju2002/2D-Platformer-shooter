using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;



public class ScorePoints : MonoBehaviour
{
    public static int scoreValue;
    public static int hiScoreCount;
    
    TMP_Text score;
    TMP_Text hiScore;
   

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("Hiscore"))
        {
            hiScoreCount = PlayerPrefs.GetInt("Hiscore");
        }
        score = GetComponent<TMP_Text>();
        hiScore = GetComponent<TMP_Text>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreValue > hiScoreCount) { 
        
            hiScoreCount = scoreValue;
            PlayerPrefs.SetInt("Hiscore", hiScoreCount);
        }

        score.text = "" + scoreValue;
        hiScore.text = "HS: " + hiScoreCount;
       
    }
}
