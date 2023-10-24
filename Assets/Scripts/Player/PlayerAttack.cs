using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDamage : MonoBehaviour
{
    [SerializeField] private float playerDamage;
    private EnemyMovement playerMovement;

    private void Start()
    {
        playerMovement = GetComponentInParent<EnemyMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            playerMovement.isAttacking = true;
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(playerDamage);
        }
    }
}
