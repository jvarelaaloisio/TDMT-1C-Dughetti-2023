using UnityEngine;

//TODO: TP2 - Fix - Merge with EnemyView after merging movement scripts
[RequireComponent(typeof(Animator))]
public class BossView : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private BossMovement bossMovement;

    private void Start()
    {
        animator = GetComponent<Animator>();
        bossMovement = GetComponentInParent<BossMovement>();
    }

    //TODO: TP2 - Syntax - Consistency in access modifiers (private/protected/public/etc)
    private void Update()
    {
        //TODO: TP2 - Fix - Hardcoded value/s
        animator.SetBool("isAttacking", bossMovement.isAttacking);
        animator.SetBool("isDamaged", bossMovement.health.isDamaged);
        animator.SetBool("isDead", bossMovement.health.isDead);
    }
}
