using UnityEngine;

public class CharacterView : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private bool hasIdleState = false;

    //TODO: TP2 - Syntax - Consistency in access modifiers (private/protected/public/etc)
    private void Update()
    {
        bool isRunning = GetComponentInParent<CharacterMovement>().GetDirection().x != 0f;

        if(hasIdleState)
            animator.SetBool("isRunning", isRunning);
        animator.SetBool("isAttacking", GetComponentInParent<CharacterMovement>().isAttacking);
        //animator.SetBool("isDamaged", GetComponentInParent<CharacterHealth>().isDamaged);
        //animator.SetBool("isDead", GetComponentInParent<CharacterHealth>().isDead);
    }

    /*IEnumerator TakeDamageAnimation()
    {
        const float animationInterval = 0.3f;
        bool playAnimation = true;

        while (playAnimation)
        {
            yield return new WaitForSeconds(animationInterval);
            playAnimation = false;
        }
    }*/

    public bool IsAnimationBeingPlayed(string stateName)
    {
        Debug.Log("Anim time: " + animator.GetCurrentAnimatorStateInfo(0).normalizedTime);
        return animator.GetCurrentAnimatorStateInfo(0).IsName(stateName) && animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1;
    }
}
