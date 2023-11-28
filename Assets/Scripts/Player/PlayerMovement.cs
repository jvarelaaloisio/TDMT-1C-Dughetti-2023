using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Timeline.TimelinePlaybackControls;

//TODO: TP2 - Fix - Character movement must be unified into a single script 
public class PlayerMovement : MonoBehaviour
{
    // Delegates
    public delegate void OnPlayerJump();
    public static OnPlayerJump onPlayerJump;
    public delegate void OnPlayerAttack();
    public static OnPlayerAttack onPlayerAttack;
    public delegate void OnPlayerMove();
    public static OnPlayerMove onPlayerMove;

    // Input Reader
    [SerializeField] private InputReader inputReader;

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
    
    private void Start()
    {
        health = GetComponent<PlayerHealth>();

        /*onPlayerMove += Move;
        onPlayerAttack += Attack;
        onPlayerJump += Jump;*/
    }

    void Update()
    {
        if (isAttacking)
        {
            timerBetweenAttacks -= Time.deltaTime;
            if (timerBetweenAttacks <= 0)
            {
                isAttacking = false;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackArea.position, attackRange);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //TODO: TP2 - Fix - Hardcoded value/s
        if(collision.gameObject.tag == "Ground")
            isGrounded = true;
    }
}
