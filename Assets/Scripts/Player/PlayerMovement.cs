using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    
    public PlayerHealth health;

    public float horizontal;
    [SerializeField] private float speed = 8f;
    [SerializeField] private float jumpingPower = 16f;
    private bool isFacingRight = true;
    public bool isGrounded = true;
    public bool isAttacking;

    // Attack
    [SerializeField] private Transform attackArea;
    [SerializeField] private LayerMask enemiesLayer;
    private float attackDelay = 0.9f;
    private float timerBetweenAttacks = 0f;
    private float attackRange = 2f;
    [SerializeField] private float attackDamage = 20f;

    private void Start()
    {
        health = GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health.isDead)
        {
            Debug.Log("Player is dead!");
        } else
        {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

            if (!isFacingRight && horizontal < 0f)
            {
                Flip();
            }
            else if (isFacingRight && horizontal > 0f)
            {
                Flip();
            }

            if(isAttacking) {
                timerBetweenAttacks -= Time.deltaTime;
                if(timerBetweenAttacks <= 0)
                {
                    isAttacking = false;
                }
            }
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && isGrounded) {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            isGrounded = false;
        } 
        
        if(context.canceled && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            isGrounded = false;
        } 
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }

    public void Attack(InputAction.CallbackContext context)
    {
        Debug.Log("Attack!");
        if (timerBetweenAttacks <= 0 && context.performed)
        {
            Debug.Log($"context.performed: {context.performed}");
            isAttacking = true;
            Collider2D[] enemiesInAttackArea = Physics2D.OverlapCircleAll(attackArea.position, attackRange, enemiesLayer);
            foreach(Collider2D enemy in enemiesInAttackArea)
            {
                enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
            }

            timerBetweenAttacks = attackDelay;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ground")
            isGrounded = true;
    }
}
