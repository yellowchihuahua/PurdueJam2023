using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMovementScript : MonoBehaviour
{
    LogicScript logicScript;

    private float moveSpeed;
    public float deadZone = -69;
    // Start is called before the first frame update
    void Start()
    {
        logicScript = GameObject.Find("Logic Manager").GetComponent<LogicScript>();
        moveSpeed = logicScript.groundScrollSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

        if (transform.position.x < deadZone)
        {
            Debug.Log("Pipe Deleted");
            Destroy(gameObject);
        }
    }
}

