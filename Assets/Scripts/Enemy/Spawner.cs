using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject original;
    [SerializeField] private int maxSpawn;
    private int spawnCount = 0;

    public List<Vector2> positions;

    private void Update()
    {
        if (transform.childCount == 0 && spawnCount < maxSpawn)
        {
            spawnCount++;
            Spawn();
        }
    }

    [ContextMenu("Spawn")]
    private void Spawn()
    {
        Instantiate(original, transform);
    }
}
