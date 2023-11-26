using System.Collections.Generic;
using UnityEngine;

//TODO: TP2 - Fix - Merge with Spawner
public class BossSpawner : MonoBehaviour
{
    [SerializeField] private GameObject boss;
    [SerializeField] private int spawnsDeadToSpawnBoss;
    private bool canSpawnBoss = true;
    
    public int spawnsDead = 0;

    public List<Vector2> positions;

    private void Update()
    {
        //TODO: TP2 - Optimization - Should be event based
        if (spawnsDead == spawnsDeadToSpawnBoss && canSpawnBoss)
        {
            SpawnBoss();
            canSpawnBoss = false;
        }
    }

    [ContextMenu("SpawnBoss")]
    private void SpawnBoss()
    {
        Instantiate(boss, transform);
    }
}
