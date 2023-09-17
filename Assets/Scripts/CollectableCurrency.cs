using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableCurrency : MonoBehaviour
{
 
    [SerializeField] private int amountToAdd = 1;
 
 
    private bool isCollected;
    private Animator animator;
    private LogicScript logic;
 
 
    void Start()
    {
        isCollected = false;
        animator = gameObject.GetComponent<Animator>();
        logic = GameObject.Find("Logic Manager").GetComponent<LogicScript>();
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

                UpdateAnimations();
            }
        }
    }

 
    private void UpdateAnimations()
    {
        animator.SetBool("_animatorIsCollected", isCollected);
    }
 
    public void DestroyAfterAnimation()
    {
        GameObject.Destroy(gameObject);
    }

}
