using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerScript : MonoBehaviour
{
    //references
    private Rigidbody2D rb2d;
    private LogicScript logic;
    private GameObject player;
    private PlayerScript playerScript;
    private Collider2D collider2d;

    //variables
    public float jumpStrength = 8f;

    //boolean flags
    public bool _isFollowerAlive = true;
    private bool _isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = this.GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<PlayerScript>();
        jumpStrength = playerScript.jumpStrength;

        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();

    }

    // Update is called once per frame
    void Update()
    {

        UpdateFollowerState();

        //add jump dampening in fixedupdate later or something
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
        float radius = 1f;

        float distance = 2f;
        LayerMask layerMask = LayerMask.GetMask("Ground");

        RaycastHit2D hitRec = Physics2D.CircleCast(origin, radius, Vector2.down, distance, layerMask);

        return hitRec.collider != null;
    }
}
