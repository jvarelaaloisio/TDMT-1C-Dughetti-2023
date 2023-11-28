using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerView : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private void Reset()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        bool isRunning = GetComponentInParent<CharacterMovement>().GetDirection().x != 0f;

        animator.SetBool("isRunning", isRunning);
        animator.SetBool("isJumping", !GetComponentInParent<CharacterMovement>().GetIsGrounded());
        animator.SetBool("isAttacking", GetComponentInParent<CharacterMovement>().isAttacking);
        //animator.SetBool("isDamaged", playerMovement.health.isDamaged);
        //animator.SetBool("isDead", playerMovement.health.isDead);
    }
}
