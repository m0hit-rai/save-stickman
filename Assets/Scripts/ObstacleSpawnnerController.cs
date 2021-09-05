using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawnnerController : MonoBehaviour
{
    public GameObject obstacle;
    public float spawnRate;
    public float maxXPos;
    // Start is called before the first frame update
    void Start()
    {
        StartSpawning(); 
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Space))
        //{
          //  Spawn();
        //}
    }

    void Spawn()
    {
        float randomX = Random.Range(-maxXPos, maxXPos);
        Vector3 spawnPos = new Vector3(randomX, transform.position.y);
        GameObject temp = Instantiate(obstacle, spawnPos, Quaternion.identity);
        temp.SetActive(true);
    }

    void StartSpawning()
    {
        InvokeRepeating("Spawn", 1f, spawnRate);
    }
    public void StopSpawning()
    {
        CancelInvoke("Spawn");
    }
}
