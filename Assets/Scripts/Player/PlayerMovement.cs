using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // Movement
    public Rigidbody2D rb;
    public float horizontal;
    [SerializeField] private float speed = 8f;
    [SerializeField] private float jumpingPower = 16f;
    private bool isFacingRight = true;

    // Animation parameters
    public bool isGrounded = true;
    public bool isAttacking;

    // Attack
    [SerializeField] private Transform attackArea;
    [SerializeField] private LayerMask enemiesLayer;
    private float attackDelay = 0.8f;
    private float timerBetweenAttacks = 0f;
    [SerializeField] private float attackDamage = 20f;
    [SerializeField] private float attackRange;
    public PlayerHealth health;

    //Audio
    [SerializeField] private CharacterAudioManager audioManager;
    
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
            if(horizontal != 0f && isGrounded)
                audioManager.PlayCharacterSteps();

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
            audioManager.PlayCharacterJump();
            isGrounded = false;
        } 
        
        if(context.canceled && rb.velocity.y > 0f && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            audioManager.PlayCharacterJump();
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
        if (timerBetweenAttacks <= 0 && context.performed)
        {
            isAttacking = true;
            Collider2D[] enemiesInAttackArea = Physics2D.OverlapCircleAll(attackArea.position, attackRange, enemiesLayer);
            foreach(Collider2D enemy in enemiesInAttackArea)
            {
                enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
            }

            timerBetweenAttacks = attackDelay;

            audioManager.PlayCharacterAttack();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackArea.position, attackRange);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ground")
            isGrounded = true;
    }
}
