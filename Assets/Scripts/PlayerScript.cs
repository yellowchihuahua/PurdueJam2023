using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    //references
    private Rigidbody2D rb2d;
    private LogicScript logic;
    private Animator animator;

    //variables
    public float jumpStrength = 8f;

    //boolean flags
    public bool _isPlayerAlive = true;
    private bool _isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = this.GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();


        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePlayerState();

        UpdateAnimations();
        //add jump dampening in fixedupdate later or something
    }

    void UpdateAnimations()
    {
        animator.SetBool("_animatorIsGrounded", _isGrounded);

        if (rb2d.velocity.y < -0.1f)
        {
            animator.SetBool("_animatorIsFalling", true);
        } else
        {
            animator.SetBool("_animatorIsFalling", false);
        }
    }

    void UpdatePlayerState()
    {
        _isGrounded = CheckGrounded();

        if (Input.GetKeyDown(KeyCode.Space) && _isPlayerAlive)
        {
            if (_isGrounded)
            {
                //jump
                rb2d.velocity = Vector2.up * jumpStrength;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ouchy")
        {
            logic.gameOVer();
            _isPlayerAlive = false;
        }
    }

    private bool CheckGrounded()
    {
        Vector2 origin = transform.position;
        float radius = 1f;

        float distance = 2f;
        LayerMask layerMask = LayerMask.GetMask("Ground");

        RaycastHit2D hitRec = Physics2D.CircleCast(origin, radius, Vector2.down, distance, layerMask);

        return hitRec.collider != null;
    }
}
