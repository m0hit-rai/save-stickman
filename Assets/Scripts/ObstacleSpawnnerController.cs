using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawnnerController : MonoBehaviour
{
    public GameObject obstacle;
    public float spawnRate;
    public float maxXPos;
    public static ObstacleSpawnnerController instance;
    // Start is called before the first frame update
    void Start()
    {
        StartSpawning();
        instance = this;

    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Space))
        //{
          //  Spawn();
        //}
    }
    public static ObstacleSpawnnerController Instance { get { return instance; } }
    void Spawn()
    {
        float randomX = Random.Range(-maxXPos, maxXPos);
        Vector3 spawnPos = new Vector3(randomX, transform.position.y);
        GameObject temp = Instantiate(obstacle, spawnPos, Quaternion.identity);
        temp.SetActive(true);
        ObstacleScript.Instance.SetGravityScale(GameManager.Instance.level * 0.5f);
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
