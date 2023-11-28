using System.Collections.Generic;
using UnityEngine;

//TODO: TP2 - Fix - Merge with BossSpawner
public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyToSpawn;
    [SerializeField] private int maxSpawn;
    [SerializeField] Spawner bossSpawner;
    [SerializeField] bool isBossSpawner;
    [SerializeField] private int spawnsDeadToSpawnBoss;

    private int spawnCount = 0;
    private int spawnsDead = 0;
    private bool canSpawnBoss;

    public List<Vector2> positions;

    private void Start()
    {
        canSpawnBoss = isBossSpawner;
    }

    private void Update()
    {
        if (isBossSpawner)
            BossSpawnerUpdate();
        else
            SpawnerUpdate();
    }

    [ContextMenu("Spawn")]
    private void Spawn()
    {
        Instantiate(enemyToSpawn, transform);
    }

    void SpawnerUpdate()
    {
        if (transform.childCount == 0 && spawnCount < maxSpawn)
        {
            spawnCount++;
            Spawn();

            if (spawnCount == maxSpawn)
            {
                bossSpawner.spawnsDead++;
            }
        }
    }

    void BossSpawnerUpdate()
    {
        //TODO: TP2 - Optimization - Should be event based
        if (spawnsDead == spawnsDeadToSpawnBoss && canSpawnBoss)
        {
            Spawn();
            canSpawnBoss = false;
        }
    }
}
