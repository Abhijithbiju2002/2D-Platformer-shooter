using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public Text scoreText;
    public Text hiScoreText;
    public static int scoreCount;
    public static int hiScoreCount;


    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("hiScore"))
        {
            hiScoreCount = PlayerPrefs.GetInt("hiScore");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreCount > hiScoreCount)
        {
            hiScoreCount = scoreCount;
            PlayerPrefs.SetInt("hiScore", hiScoreCount);
        }
        scoreText.text = "SCORE: " + scoreCount;
        hiScoreText.text = "HI-SCORE: " + hiScoreCount;
    }
}
