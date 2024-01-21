using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    public List<Wave> waves;
    public int currentWaveCount;

    private float spawnTimer;

    private void Start()
    {
        CalculateWaveQuota();
    }

    private void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= waves[currentWaveCount].spawnInterval)
        {
            spawnTimer = 0f;
            SpawnEnemies();
        }
    }

    private void CalculateWaveQuota()
    {
        int currentWaveQuota = 0;
        foreach (var enemyGroup in waves[currentWaveCount].enemyGroups)
        {
            currentWaveQuota += enemyGroup.enemyCount;
        }

        waves[currentWaveCount].waveQuota = currentWaveQuota;
        Debug.Log($"CurrentWaveQuota: {currentWaveQuota}");
    }

    private void SpawnEnemies()
    {   
        if (waves[currentWaveCount].spawnCount < waves[currentWaveCount].waveQuota)
        {
            var playerPosition = GameManager.Instance.playerController.transform.position;
            foreach (var enemyGroup in waves[currentWaveCount].enemyGroups)
            {
                if (enemyGroup.spawnCount<enemyGroup.enemyCount)
                {
                
                    Vector2 spawnPosition = new Vector2(playerPosition.x + Random.Range(-10, 10f),
                        playerPosition.y + Random.Range(-10, 10f));
                    Instantiate(enemyGroup.enemyPrefab, spawnPosition, quaternion.identity);
                    enemyGroup.spawnCount++;
                    waves[currentWaveCount].spawnCount++;
                }
            }
        }
    }
    
    
    
    
    
    
    [Serializable]
    public class Wave
    {
        public string waveName;
        public List<EnemyGroup> enemyGroups;
        public int waveQuota;
        public float spawnInterval;
        public int spawnCount;
    }
    [Serializable]
    public class EnemyGroup
    {
        public string enemyName;
        public int enemyCount;
        public int spawnCount;
        public GameObject enemyPrefab;
    }


}