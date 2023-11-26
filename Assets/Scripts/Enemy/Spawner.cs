using System.Collections.Generic;
using UnityEngine;

//TODO: TP2 - Fix - Merge with BossSpawner
public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject original;
    [SerializeField] private int maxSpawn;
    [SerializeField] BossSpawner bossSpawner;

    private int spawnCount = 0;

    public List<Vector2> positions;

    private void Update()
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

    [ContextMenu("Spawn")]
    private void Spawn()
    {
        Instantiate(original, transform);
    }
}
