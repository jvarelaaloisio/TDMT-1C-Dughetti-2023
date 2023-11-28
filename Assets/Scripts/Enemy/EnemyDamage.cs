using UnityEngine;

//TODO: TP2 - Fix - Repeated code in Boss
public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private float enemyDamage;
    private CharacterMovement characterMovement;

    private float attackDelay = 0.5f;
    private float timerBetweenAttacks = 0f;

    //Audio
    [SerializeField] private CharacterAudioManager audioManager;

    private void Start()
    {
        characterMovement = GetComponentInParent<CharacterMovement>();
    }

    private void Update()
    {
        //TODO: TP2 - Could be a coroutine/Invoke
        /*if (characterMovement.isAttacking)
        {
            timerBetweenAttacks -= Time.deltaTime;
            if (timerBetweenAttacks <= 0)
            {
                characterMovement.isAttacking = false;
            }
        }*/
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //TODO: TP2 - Fix - Hardcoded value/s
        /*if (collision.gameObject.tag == "Player" && timerBetweenAttacks <= 0)
        {
            characterMovement.isAttacking = true;
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(enemyDamage);
            timerBetweenAttacks = attackDelay;

        }*/
    }
}
