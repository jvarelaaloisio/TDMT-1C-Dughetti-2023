using UnityEngine;

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

    private void Update()
    {
        animator.SetBool("isAttacking", bossMovement.isAttacking);
        animator.SetBool("isDamaged", bossMovement.health.isDamaged);
        animator.SetBool("isDead", bossMovement.health.isDead);
    }
}
