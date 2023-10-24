using UnityEngine;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private float enemyDamage;
    private EnemyMovement enemyMovement;

    private float attackDelay = 0.5f;
    private float timerBetweenAttacks = 0f;

    private void Start()
    {
        enemyMovement = GetComponentInParent<EnemyMovement>();
    }

    private void Update()
    {
        if (enemyMovement.isAttacking)
        {
            timerBetweenAttacks -= Time.deltaTime;
            if (timerBetweenAttacks <= 0)
            {
                enemyMovement.isAttacking = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && timerBetweenAttacks <= 0)
        {
            enemyMovement.isAttacking = true;
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(enemyDamage);
            timerBetweenAttacks = attackDelay;
        }
    }
}
