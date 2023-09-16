using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMovementScript : MonoBehaviour
{
    LogicScript logicScript;

    private float groundMoveSpeed;
    public float deadZone = -133f;

    void Start()
    {
        logicScript = GameObject.Find("Logic Manager").GetComponent<LogicScript>();
        groundMoveSpeed = logicScript.groundScrollSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * groundMoveSpeed) * Time.deltaTime;

        if (transform.position.x < deadZone) { 
            Destroy(gameObject);
        }
    }
}

