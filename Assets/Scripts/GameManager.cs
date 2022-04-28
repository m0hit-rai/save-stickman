using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    bool gameOver = false;
    int score = 0;
    public int level = 1;
    public Text scoreText;
    public Text levelText;
    public GameObject gameOverPanel;
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
            /*print(score);*/
            if((level-1)<(score/100))
            {
                level += 1;
                levelText.text = "Level - " + level.ToString();
                StickmanController.Instance.increseMoveSpeed();
            }
        }
    }
    public static GameManager Instance { get { return instance; } }
    public void GameOver()
    {
        gameOver = true;
        GameObject.Find("ObstacleSpawnner").GetComponent<ObstacleSpawnnerController>().StopSpawning();
        gameOverPanel.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
