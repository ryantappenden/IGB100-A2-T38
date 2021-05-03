using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;

    private float gameTime = 10.0f;

    public float spawnRate = 5.0f;
    private float spawnTimer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnEnemy();
        GameStage();
    }

    private void SpawnEnemy()
    {
        if(Time.time > spawnTimer && Time.time <= 200)
        {  
            Instantiate(enemy, transform.position, transform.rotation);
            spawnTimer = Time.time + spawnRate;
        }            
    }

    private void GameStage()
    {
        if(Time.time >= gameTime && spawnRate >= 2)
        {
            spawnRate = spawnRate - 1;
            gameTime = gameTime + 25;
        }
    }
}
