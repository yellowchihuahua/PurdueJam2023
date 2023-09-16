using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;

    public int currentHeadcount;
    public Text currentHeadcountText;
    public GameObject gameOverScreen;
    public float groundScrollSpeed = 5f;

    public void addScore(int num)
    {
        playerScore = playerScore + num;
        scoreText.text = playerScore.ToString();
    }

    public void addHeadcount(int num)
    {
        currentHeadcount = currentHeadcount + num;
        currentHeadcountText.text = currentHeadcount.ToString();

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
