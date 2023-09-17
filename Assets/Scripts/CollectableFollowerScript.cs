using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableFollowerScript : MonoBehaviour
{
    public GameObject followerPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //spawn the follower cow and delete the current cow
            Instantiate(followerPrefab, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
            Destroy(gameObject);
        }
    }
}
