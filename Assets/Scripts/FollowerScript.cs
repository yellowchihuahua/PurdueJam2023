using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerScript : MonoBehaviour
{
    //references
    private Rigidbody2D rb2d;

    private Collider2D collider2d;
    private Animator animator;
    
    public LogicScript logic;
    private GameObject player;
    private PlayerScript playerScript;

    //variables
    public float jumpStrength = 8f;
    public float groundCheckRadius = 0.5f;
    public float groundCheckDistance = 0.4f;

    //boolean flags
    public bool _isFollowerAlive = true;
    private bool _isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = this.GetComponent<Rigidbody2D>();
        collider2d = this.GetComponent<Collider2D>();
        animator = this.GetComponent<Animator>();
        
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<PlayerScript>();
        jumpStrength = playerScript.jumpStrength;

    }

    private void OnEnable() //enable is before Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        logic.addHeadcount(1);
    }

    // Update is called once per frame
    void Update()
    {

        UpdateFollowerState();

        UpdateAnimations();

        //add jump dampening in fixedupdate later or something
    }

    void UpdateAnimations()
    {
        animator.SetBool("_animatorIsGrounded", _isGrounded);

        if (rb2d.velocity.y < -0.1f)
        {
            animator.SetBool("_animatorIsFalling", true);
        }
        else
        {
            animator.SetBool("_animatorIsFalling", false);
        }
    }

    void UpdateFollowerState()
    {
        _isGrounded = CheckGrounded();

        if (Input.GetKeyDown(KeyCode.Space) && _isFollowerAlive && playerScript._isPlayerAlive)
        {
            
            //calculate seconds needed before jumping
            float distanceToPlayer = player.transform.position.x - transform.position.x;
            float offset = distanceToPlayer / (logic.groundScrollSpeed);

            //invoke jump after x secords
            Invoke("Jump", offset);
        }
    }

    void Jump()
    {
        if (_isGrounded)
        {
            rb2d.velocity = Vector2.up * jumpStrength;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ouchy")
        {
            //die
            _isFollowerAlive = false;
            collider2d.enabled = false;

            logic.addHeadcount(-1);

            Invoke("DeleteSelf", 5);
        }
    }

    private void DeleteSelf()
    {
        Destroy(gameObject);
    }

    private bool CheckGrounded()
    {
        Vector2 origin = transform.position;

        LayerMask layerMask = LayerMask.GetMask("Ground");

        RaycastHit2D hitRec = Physics2D.CircleCast(origin, groundCheckRadius, Vector2.down, groundCheckDistance, layerMask);

        Debug.Log(hitRec.collider);
        return hitRec.collider != null;
    }
}
