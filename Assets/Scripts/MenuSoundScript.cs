using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSoundScript : MonoBehaviour
{
    //this is no longer a sound script, just to fade the intro to white
    public GameObject fadeToWhitePanel;
    private bool _isTransitioning = false;

    private void Start()
    {
        fadeToWhitePanel.SetActive(false);
    }
    public void SetIsTransitioning()
    {
        fadeToWhitePanel.SetActive(true);
        _isTransitioning = true;
    }

    private void Update()
    {
        if (_isTransitioning)
        {
            Image image = fadeToWhitePanel.GetComponent<Image>();
            image.color = new Color(255, 255, 255, image.color.a + (float)(1 * Time.deltaTime));
        }
    }


}
