using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore = 0;
    public Text scoreText;

    public int currentHeadcount = 0;
    public Text currentHeadcountText;

    public int topHeadcount = 0;
    public GameObject gameOverScreen;
    public float groundScrollSpeed = 5f;

    public Text gameOverTopHeadcount;
    public Text gameOverHeadcount;
    public Text gameOverScore;

    public void addScore(int num)
    {
        playerScore = playerScore + num;
        string text = "Score: " + playerScore.ToString();
        scoreText.text = text;
        gameOverScore.text = text;
    }

    public void addHeadcount(int num)
    {
        currentHeadcount = currentHeadcount + num;
        currentHeadcountText.text = "Herd: " + currentHeadcount.ToString();

        if (currentHeadcount > topHeadcount)
        {
            topHeadcount = currentHeadcount;
            
        }
    }
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void gameOVer()
    {
        gameOverHeadcount.text = "Herd Size: " + currentHeadcount.ToString();
        gameOverTopHeadcount.text = "Max Herd Size: " + topHeadcount.ToString();
        gameOverScore.text = "Score: " + playerScore.ToString();
        gameOverScreen.SetActive(true);
    }
}
