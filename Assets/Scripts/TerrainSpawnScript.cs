using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainSpawnScript : MonoBehaviour
{
    public GameObject[] chunks;
    public LogicScript logic;


    public float objectLength = 100f;
    public float spawnRate = 10f;
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        SpawnTerrain();
        logic = GameObject.Find("Logic Manager").GetComponent<LogicScript>();
        spawnRate = objectLength / logic.groundScrollSpeed; //each chunk is 100 units in length i believe?
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            SpawnTerrain();
            timer = 0;
        }
    }

    void SpawnTerrain()
    {
        Instantiate(chunks[Random.Range(0, chunks.Length - 1)], new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);

    }
}
