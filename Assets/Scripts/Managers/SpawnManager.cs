using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Player player;
    
    [Header("Data")]
    public int enemiesKilled;
    public int enemiesSpawned;
    public int enemySpawnAmount;
    public int waveNumber;  
    public int totalWaves;
    [SerializeField]
    Spawner spawner;

    void Start()
    {
        spawner = FindObjectOfType<Spawner>();
        Invoke("StartWave", 2.5f);
    }

    void Update()
    {
        
    }

    public void StartWave()
    {
        waveNumber = 1;
        enemiesKilled = 0;
        enemiesSpawned = 0;
        spawner.Spawn();
    }
    
    public void NextWave()
    {
        waveNumber++;
        enemiesKilled = 0;
        enemiesSpawned = 0;
        enemySpawnAmount++;
        spawner.Spawn();
    }
}
