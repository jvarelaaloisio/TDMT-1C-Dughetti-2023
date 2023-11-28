using System.Collections;
using UnityEngine;

//TODO: TP2 - Fix - Merge with BossView after merging movement scripts
[RequireComponent(typeof(Animator))]
public class EnemyView : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    //TODO: TP2 - Syntax - Consistency in access modifiers (private/protected/public/etc)
    private void Update()
    {
        //TODO: TP2 - Fix - Hardcoded value/s
        /*animator.SetBool("isAttacking", GetComponentInParent<CharacterMovement>().isAttacking);
        animator.SetBool("isDamaged", GetComponentInParent<CharacterHealth>().isDamaged);
        animator.SetBool("isDead", GetComponentInParent<CharacterHealth>().isDead);*/
    }

    IEnumerator TakeDamageAnimation()
    {
        const float animationInterval = 0.3f;

        while (true)
        {
            yield return new WaitForSeconds(animationInterval);
        }
    }

    bool IsAnimationBeingPlayed(string stateName)
    {
        return animator.GetCurrentAnimatorStateInfo(0).IsName(stateName) && animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1;
    }
}