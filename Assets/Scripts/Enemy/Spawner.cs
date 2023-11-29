using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: TP2 - Fix - Merge with BossSpawner
public class Spawner : MonoBehaviour
{
    // Animation
    private bool isDestroyed = false;
    private SpawnView spawnView;

    [SerializeField] private GameObject enemyToSpawn;
    [SerializeField] private int maxSpawn;

    private LevelHandler levelHandler;

    private int spawnCount = 0;

    public List<Vector2> positions;

    private void Start()
    {
        levelHandler = GameObject.FindWithTag("LevelHandler").GetComponent<LevelHandler>();
        spawnView = gameObject.GetComponentInChildren<SpawnView>();
        if(spawnView != null)
        {
            Spawn();
        }
    }

    [ContextMenu("Spawn")]
    public void Spawn()
    {
        if (spawnCount < maxSpawn)
        {
            spawnCount++;
            Instantiate(enemyToSpawn, transform);
        }
        else if (spawnCount == maxSpawn)
        {
            StartCoroutine(DestroySpawn());
        }
    }

    public bool GetIsDestroyed()
    {
        return isDestroyed;
    }

    IEnumerator DestroySpawn()
    {
        isDestroyed = true;
        yield return new WaitUntil(() => spawnView.IsCurrentAnimationDestroy());
        levelHandler.IncreaseDefeatedSpawnerCount();
        yield return new WaitUntil(() => !spawnView.IsAnimationBeingPlayed());
        this.gameObject.SetActive(false);
    }
}
