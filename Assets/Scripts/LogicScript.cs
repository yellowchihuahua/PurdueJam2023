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
    public GameObject gameOverScreen;
    public float groundScrollSpeed = 5f;

    public void addScore(int num)
    {
        playerScore = playerScore + num;
        scoreText.text = "Score: " + playerScore.ToString();
    }

    public void addHeadcount(int num)
    {
        currentHeadcount = currentHeadcount + num;
        currentHeadcountText.text = "Herd: " + currentHeadcount.ToString();

    }
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void gameOVer()
    {
        gameOverScreen.SetActive(true);
    }
}
