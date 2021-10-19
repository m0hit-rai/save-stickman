using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    bool gameOver = false;
    int score = 0;
    public Text scoreText;
    private void Awake()
    {
        instance = this;
    }

    public void incrementScore()
    {
        if(!gameOver)
        {
            score+=10;
            string scoreString = score.ToString();
            while(scoreString.Length<3)
            {
                scoreString = "0" + scoreString;
            }
            scoreText.text = scoreString;
            print(score);
        }
    }

    public void GameOver()
    {
        gameOver = true;
        GameObject.Find("ObstacleSpawnner").GetComponent<ObstacleSpawnnerController>().StopSpawning();
    }
}
