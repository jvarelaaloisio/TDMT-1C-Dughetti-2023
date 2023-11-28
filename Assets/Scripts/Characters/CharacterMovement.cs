using System.Collections;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    //Animation
    public bool isAttacking;

    // Attack
    [SerializeField] private Transform attackArea;
    [SerializeField] private LayerMask enemiesLayer;
    [SerializeField] private float attackDamage = 20f;
    [SerializeField] private float attackRange = 1f;
    [SerializeField] private CharacterView characterView;

    //Movement
    private bool isFacingRight = true;
    private bool isGrounded = true;
    private string groundTag = "Ground";
    [SerializeField] private float jumpingPower = 16f;
    [SerializeField] private float speed = 8f;
    [SerializeField] private Vector2 direction;

    // Sound
    [SerializeField] private CharacterAudioManager characterAudioManager;

    public void Update()
    {
        if(direction.x != 0f)
            Move();
    }

    public bool GetIsGrounded()
    {
        return isGrounded;
    }

    public bool GetIsAttacking()
    {
        return isAttacking;
    }

    public Vector2 GetDirection()
    {
        return direction;
    }

    public void SetDirection(Vector2 inputDirection)
    {
        direction = new Vector2(inputDirection.x, inputDirection.y);
    }

    public void Move()
    {
        if (isGrounded)
            characterAudioManager.PlayCharacterSteps();

        GetComponent<Transform>().position += new Vector3(direction.x, direction.y) * speed * Time.deltaTime;

        if (!isFacingRight && direction.x < 0f)
        {
            Flip();
        }
        else if (isFacingRight && direction.x > 0f)
        {
            Flip();
        }
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    public void Jump()
    {
        if (isGrounded)
        {
            characterAudioManager.PlayCharacterJump();
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpingPower);
            isGrounded = false;
        }
    }

    public void Attack()
    {
        if(!isAttacking)
        {
            isAttacking = true;
            characterAudioManager.PlayCharacterAttack();
            StartCoroutine(AttackEnemy());
        }
    }

    IEnumerator AttackEnemy()
    {
        yield return new WaitUntil(() => characterView.IsCurrentAnimationAttack());

        Collider2D[] enemiesInAttackArea = Physics2D.OverlapCircleAll(attackArea.position, attackRange, enemiesLayer);
        foreach (Collider2D enemy in enemiesInAttackArea)
        {
            enemy.GetComponent<CharacterHealth>().TakeDamage(attackDamage);
        }

        yield return new WaitUntil(() => !characterView.IsAnimationBeingPlayed());
        isAttacking = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackArea.position, attackRange);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //TODO: TP2 - Fix - Hardcoded value/s
        if (collision.gameObject.tag == groundTag)
            isGrounded = true;
    }
}
