using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerView : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerMovement playerMovement;

    private void Reset()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        bool isRunning = playerMovement.horizontal != 0f;

        animator.SetBool("isRunning", isRunning);
        animator.SetBool("isJumping", !playerMovement.isGrounded);
        animator.SetBool("isAttacking", playerMovement.isAttacking);
        animator.SetBool("isDamaged", playerMovement.health.isDamaged);
        animator.SetBool("isDead", playerMovement.health.isDead);
    }
}
