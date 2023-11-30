using UnityEngine;

public class CharacterView : MonoBehaviour
{
    [SerializeField] private Animator animator;
    //Enemies don't have idle state, only player does
    [SerializeField] private bool hasIdleState = false;
    //Enemies don't have jump state, only player does
    [SerializeField] private bool hasJumpState = false;
    //Only boss has special attack
    [SerializeField] private bool hasSpecialAttack = false;

    [SerializeField] private CharacterMovement characterMovement;
    [SerializeField] private CharacterHealth characterHealth;

    // Character animation names
    private string attackAnimationName = "Attack";
    private string specialAttackAnimationName = "SpecialAttack";
    private string damageAnimationName = "Damage";
    private string deathAnimationName = "Death";

    //TODO: TP2 - Syntax - Consistency in access modifiers (private/protected/public/etc)
    private void Update()
    {
        bool isRunning = GetComponentInParent<CharacterMovement>().GetDirection().x != 0f;

        if(hasIdleState)
            animator.SetBool("isRunning", isRunning);
        if (hasJumpState)
            animator.SetBool("isJumping", characterMovement.GetIsGrounded());
        if(hasSpecialAttack)
            animator.SetBool("isSpecialAttacking", characterMovement.isSpecialAttacking);

        animator.SetBool("isAttacking", characterMovement.GetIsAttacking());

        animator.SetBool("isDamaged", characterHealth.GetIsDamaged());
        animator.SetBool("isDead", characterHealth.GetIsDead());
    }

    public bool IsAnimationBeingPlayed()
    {
        return animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1;
    }

    private bool IsCurrentAnimation(string stateName)
    {
        return animator.GetCurrentAnimatorStateInfo(0).IsName(stateName);
    }

    public bool IsCurrentAnimationAttack()
    {
        return IsCurrentAnimation(attackAnimationName);
    }

    public bool IsCurrentAnimationSpecialAttack()
    {
        return IsCurrentAnimation(specialAttackAnimationName);
    }

    public bool IsCurrentAnimationDamage()
    {
        return IsCurrentAnimation(damageAnimationName);
    }

    public bool IsCurrentAnimationDeath()
    {
        return IsCurrentAnimation(deathAnimationName);
    }
}
