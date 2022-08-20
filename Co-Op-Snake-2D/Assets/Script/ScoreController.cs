using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ScoreController : MonoBehaviour
{
    private Snake1Controller snake1Controller;
    private Text HighScoreText;
    private int max;
    public Text scoreText;
    private int scoreValue = 0;
   


   public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("food"))
        {
            scoreValue++;
            scoreText.text ="Score Player 1: "+ scoreValue.ToString();
        }
        else if (other.CompareTag("Poisen"))
        {
            scoreValue--;
            scoreText.text = "Score Player 1: " + scoreValue.ToString();
            if(scoreValue < 0)
            {
                scoreValue = 0;
               // snake1Controller.ResetState();
            }
            
        }
    }
}

