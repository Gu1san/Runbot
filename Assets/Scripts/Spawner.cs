using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemies;
    [SerializeField]
    private int enemyID;
    [SerializeField]
    Transform[] points;
    SpawnManager spawnManager;
    int index = 0;

    void Start()
    {
        spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
    }

    void Update()
    {
        
    }

    public void Spawn()
    {
        
        if (spawnManager.waveNumber <= spawnManager.totalWaves)
        {
            if (spawnManager.enemiesSpawned < spawnManager.enemySpawnAmount)
            {
                
                if (enemies.Length == 1)
                {
                    Instantiate(enemies[0], points[index].position, transform.rotation);
                }
                else
                {
                    if (enemyID < enemies.Length)
                    {
                        Instantiate(enemies[enemyID], points[index].position, transform.rotation);
                        enemyID++;
                    }
                    else
                    {
                        enemyID = 0;
                        Instantiate(enemies[enemyID], points[index].position, transform.rotation);
                        enemyID++;
                    }
                }
                index++;
                spawnManager.enemiesSpawned++;
                if(index >= points.Length)
                {
                    index = 0;
                }
                Invoke("Spawn", 2.5f);
            }
        }
    }
}
