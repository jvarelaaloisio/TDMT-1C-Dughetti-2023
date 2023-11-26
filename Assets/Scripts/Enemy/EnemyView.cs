using UnityEngine;

//TODO: TP2 - Fix - Merge with BossView after merging movement scripts
[RequireComponent(typeof(Animator))]
public class EnemyView : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private EnemyMovement enemyMovement;

    private void Start()
    {
        animator = GetComponent<Animator>();
        enemyMovement = GetComponentInParent<EnemyMovement>();
    }

    //TODO: TP2 - Syntax - Consistency in access modifiers (private/protected/public/etc)
    private void Update()
    {
        //TODO: TP2 - Fix - Hardcoded value/s
        animator.SetBool("isAttacking", enemyMovement.isAttacking);
        animator.SetBool("isDamaged", enemyMovement.health.isDamaged);
        animator.SetBool("isDead", enemyMovement.health.isDead);
    }
}
