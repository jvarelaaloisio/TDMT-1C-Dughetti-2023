using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInput : MonoBehaviour
{
    // Movement
    [SerializeField] private CharacterMovement characterMovement;
    private float threshold = 0.1f;
    private int currentIndex = 0;
    private Spawner spawner;

    private void Start()
    {
        spawner = GetComponentInParent<Spawner>();
    }

    private void Update()
    {
        Move();
    }

    public void Move()
    {
        Vector2 nextPosition = spawner.positions[currentIndex];
        Vector2 currentPosition = transform.position;

        Vector2 directionToNextPos = nextPosition - currentPosition;
        directionToNextPos.Normalize();

        characterMovement.SetDirection(directionToNextPos);

        if ((currentPosition - nextPosition).magnitude < threshold)
        {
            currentIndex++;
            if (currentIndex >= spawner.positions.Count)
            {
                currentIndex = 0;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //TODO: TP2 - Fix - Hardcoded value/s
        characterMovement.Attack();
    }
}
