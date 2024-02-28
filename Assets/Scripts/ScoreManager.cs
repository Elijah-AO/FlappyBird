using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class ScoreManager : MonoBehaviour
{

    public TextMeshProUGUI scoreText; // Reference to the TextMeshProUGUI component
    public TextMeshProUGUI highScoreText;
    private int score; // Internal score counter
    public static int highScore;
    public TMP_FontAsset newFontAsset; 

    /*private void Awake(){
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }*/
    void Start()
    {   scoreText.font = newFontAsset;
        highScoreText.font = newFontAsset;
        int score = 0; // Initialize the score
        UpdateScoreText(score); // Update the score display
    }

    // Call this method to increase the score
    public void IncreaseScore(){
        score ++;
        UpdateScoreText(score); // Update the score display
    }

    public void saveHighScore(){
        if (score > highScore)
{      
            // Save the new high score
            highScore = score;

}
    }

    // Update the score text display
    private void UpdateScoreText(int score)
    {
        scoreText.font = newFontAsset;
        highScoreText.font = newFontAsset;
        scoreText.text = score.ToString();
        highScoreText.text = highScore.ToString();
    }
    
}
