using UnityEngine;

public class BossDamage : MonoBehaviour
{
    [SerializeField] private float enemyDamage;
    private BossMovement bossMovement;

    private float attackDelay = 0.5f;
    private float timerBetweenAttacks = 0f;

    //Audio
    [SerializeField] private CharacterAudioManager audioManager;

    private void Start()
    {
        bossMovement = GetComponentInParent<BossMovement>();
    }

    private void Update()
    {
        //TODO: TP2 - Could be a coroutine/Invoke
        if (bossMovement.isAttacking)
        {
            timerBetweenAttacks -= Time.deltaTime;
            if (timerBetweenAttacks <= 0)
            {
                bossMovement.isAttacking = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //TODO: TP2 - Fix - Hardcoded value/s
        if (collision.gameObject.tag == "Player" && timerBetweenAttacks <= 0)
        {
            bossMovement.isAttacking = true;
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(enemyDamage);
            timerBetweenAttacks = attackDelay;

            audioManager.PlayCharacterAttack();
        }
    }
}
