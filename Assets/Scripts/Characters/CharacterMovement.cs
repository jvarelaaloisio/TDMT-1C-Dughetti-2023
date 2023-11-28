using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    //Movement
    private bool isFacingRight = true;
    private bool isGrounded = true;
    private string groundTag = "Ground";
    [SerializeField] private float jumpingPower = 16f;
    [SerializeField] private float speed = 8f;
    [SerializeField] private Vector2 direction;

    //Attack
    [SerializeField] private Transform attackArea;
    [SerializeField] private LayerMask enemiesLayer;
    private float attackDelay = 0.8f;
    private float timerBetweenAttacks = 0f;
    [SerializeField] private float attackDamage = 20f;
    [SerializeField] private float attackRange;
    [SerializeField] private CharacterView characterView;

    //Animation
    public bool isAttacking;

    public void Update()
    {
        if(direction.x != 0f)
            Move();
    }

    public bool GetIsGrounded()
    {
        return isGrounded;
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
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpingPower);
            isGrounded = false;
        }
    }

    public void Attack()
    {
        Debug.Log("Attack!");
        if(!isAttacking)
        {
            StartCoroutine(AttackEnemy());
        }
        /*if (!characterView.IsAnimationBeingPlayed("Attack"))
        {
            isAttacking = true;
            Collider2D[] enemiesInAttackArea = Physics2D.OverlapCircleAll(attackArea.position, attackRange, enemiesLayer);
            foreach (Collider2D enemy in enemiesInAttackArea)
            {
                enemy.GetComponent<CharacterHealth>().TakeDamage(attackDamage);
            }
            
        }*/
    }

    IEnumerator AttackEnemy()
    {
        isAttacking = true;
        while(isAttacking)
        {
            Debug.Log("Start Attack");
            yield return new WaitUntil(() => !characterView.IsAnimationBeingPlayed("Attack"));
            Debug.Log("End Attack");
            isAttacking = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //TODO: TP2 - Fix - Hardcoded value/s
        if (collision.gameObject.tag == groundTag)
            isGrounded = true;
    }
}
