using UnityEngine;

public class SpawnView : MonoBehaviour
{
    private Spawner spawner;
    private Animator animator;

    // Character animation names
    private string destroyAnimationName = "Destroy";

    private void Start()
    {
        spawner = GetComponentInParent<Spawner>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        animator.SetBool("isDestroyed", spawner.GetIsDestroyed());
    }

    public bool IsAnimationBeingPlayed()
    {
        return animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1;
    }

    public bool IsCurrentAnimationDestroy()
    {
        return animator.GetCurrentAnimatorStateInfo(0).IsName(destroyAnimationName);
    }
}
