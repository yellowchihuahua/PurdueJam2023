using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyScrollScript : MonoBehaviour
{
    LogicScript logicScript;

    private float groundMoveSpeed;
    public float speedMultiplier = 0.5f;
    public float deadZone = -20f;

    void Start()
    {
        logicScript = GameObject.Find("Logic Manager").GetComponent<LogicScript>();
        groundMoveSpeed = logicScript.groundScrollSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * groundMoveSpeed * speedMultiplier) * Time.deltaTime;

        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
    }
}
