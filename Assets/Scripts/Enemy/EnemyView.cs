using UnityEngine;

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

    private void Update()
    {
        animator.SetBool("isAttacking", enemyMovement.isAttacking);
        animator.SetBool("isDamaged", enemyMovement.health.isDamaged);
        animator.SetBool("isDead", enemyMovement.health.isDead);
    }
}
