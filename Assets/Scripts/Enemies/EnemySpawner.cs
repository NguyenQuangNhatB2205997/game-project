using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public string waveName;
        public int waveQuota; // total number of enemies to spawn
        public float spawnInterval; // the interval to spawn enemies
        public float spawnCount; // total number of enemies already spawned
        public List<EnemyGroup> enemyGroups; // list of enemy groups in this wave
    }

    //creat enemyGroup class for simplicity
    [System.Serializable]
    public class EnemyGroup
    {
        public string enemyName; // name of the enemy group
        public GameObject enemyPrefab; // list of enemy prefabs in this group
        public int enemyCount; // number of each enemy type in this group
        public int spawnCount; // total number of enemies of this group already spawned
    }

    public List<Wave> waves; // list of waves to spawn
    public int currentWaveCount; // current wave count (starts from 0)

    [Header("Spawner Attributes")]
    float spawnTimer; // timer to spawn enemies
    public float waveInterval; // interval between waves

    Transform player;

    void Start()
    {
        player = GameObject.FindFirstObjectByType<PlayerStats>().transform; 
        CalculateWaveQuota();
        SpawnEnemies();
    }

    void Update()
    {
        // Check if the current wave is completed
        if (currentWaveCount < waves.Count && waves[currentWaveCount].spawnCount == 0)
        {
            StartCoroutine(SpawnNextWave());
        }
        // Update the spawn timer
        spawnTimer += Time.deltaTime;

        // check if it's time to spawn next enemies
        if (spawnTimer >= waves[currentWaveCount].spawnInterval)
        {
            spawnTimer = 0f; // reset the timer after spawning
            SpawnEnemies();
        }
    }
    
    IEnumerator SpawnNextWave()
    {
        // Wait for the wave interval before spawning the next wave
        yield return new WaitForSeconds(waveInterval); 
        
        // if there are more waves to spawn, move on to the next wave
        if (currentWaveCount < waves.Count - 1)
        {
            currentWaveCount++;
            CalculateWaveQuota();
        }
    }

    void CalculateWaveQuota()
    {
        int currentWaveQuota = 0;
        foreach (var enemyGroup in waves[currentWaveCount].enemyGroups)
        {
            currentWaveQuota += enemyGroup.enemyCount;
        }
        waves[currentWaveCount].waveQuota = currentWaveQuota;
        Debug.Log("Current Wave Quota: " + currentWaveQuota);
    }

    void SpawnEnemies()
    {
        // Check if the minimum spawn count for the current wave has been reached
        if (waves[currentWaveCount].spawnCount < waves[currentWaveCount].waveQuota)
        {
            // spawn each type of enemy until the quota is reached
            foreach (var enemyGroup in waves[currentWaveCount].enemyGroups)
            {
                // Check if the minimum spawn count for the enemy group has been reached
                if (enemyGroup.spawnCount < enemyGroup.enemyCount)
                {
                    // Spawn the enemy randomly at player's position's range
                    Vector2 spawnPostiion = new Vector2(player.transform.position.x + Random.Range(-10f, 10f), player.transform.position.y + Random.Range(-10f, 10f));

                    Instantiate(enemyGroup.enemyPrefab, transform.position, Quaternion.identity);
                    enemyGroup.spawnCount++;
                    waves[currentWaveCount].spawnCount++;
                }
            }
        }
    }
}