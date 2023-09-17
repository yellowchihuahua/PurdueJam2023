using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableCurrency : MonoBehaviour
{

    [SerializeField] private int amountToAdd = 1;


    private bool isCollected = false;
    private Animator animator;
    private LogicScript logic;
    private AudioSource audioSource;

    void Start()
    {
        isCollected = false;
        animator = gameObject.GetComponentInChildren<Animator>();
        logic = GameObject.Find("Logic Manager").GetComponent<LogicScript>();
        audioSource = gameObject.GetComponent<AudioSource>();

    }

    void OnEnable()
    {

    }


    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!isCollected)
            {
                logic.addScore(amountToAdd);
                isCollected = true;

                PlayGemSound();
                UpdateAnimations();
            }
        }
    }

    void PlayGemSound()
    {
        audioSource.Play();
    }
 
    private void UpdateAnimations()
    {
        animator.SetBool("_animatorIsCollected", isCollected);
    }

}
