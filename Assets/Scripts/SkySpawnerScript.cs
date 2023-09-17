using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkySpawnerScript : MonoBehaviour
{
    
    public GameObject skyBack;
    public GameObject skyMid;
    public GameObject skyFront;
    public float objectLength = 24f;
    private LogicScript logic;

    private float backSpawnRate;
    private float midSpawnRate;
    private float frontSpawnRate;

    private float backTimer = 0;
    private float midTimer = 0;
    private float frontTimer = 0;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.Find("Logic Manager").GetComponent<LogicScript>();


        SpawnSky(skyBack);
        SpawnSky(skyMid);
        SpawnSky(skyFront);

        backSpawnRate = objectLength / (skyBack.GetComponent<SkyScrollScript>().speedMultiplier * logic.groundScrollSpeed);
        midSpawnRate = objectLength / (skyMid.GetComponent<SkyScrollScript>().speedMultiplier * logic.groundScrollSpeed);
        frontSpawnRate = objectLength / (skyFront.GetComponent<SkyScrollScript>().speedMultiplier * logic.groundScrollSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        //we are not gonna talk about how jank the code is
        if (backTimer <= backSpawnRate)
        {
            backTimer += Time.deltaTime;
        }
        else
        {
            SpawnSky(skyBack);
            backTimer = 0;
        }

        //mid
        if (midTimer <= midSpawnRate)
        {
            midTimer += Time.deltaTime;
        }
        else
        {
            SpawnSky(skyMid);
            midTimer = 0;
        }

        //front
        if (frontTimer <= frontSpawnRate)
        {
            frontTimer += Time.deltaTime;
        }
        else
        {
            SpawnSky(skyFront);
            frontTimer = 0;
        }
    }

    void SpawnSky(GameObject prefab)
    {
        Instantiate(prefab, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);

    }

}
