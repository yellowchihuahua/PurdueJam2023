using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    //class to hold scene management functions

    public void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }


}