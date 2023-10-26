using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed = 1f;

    private Spawner spawner;

    public EnemyHealth health;

    private float threshold = 0.1f;
    private int currentIndex = 0;
    private bool isFacingRight = false;

    public bool isAttacking = false;

    //Audio
    [SerializeField] private CharacterAudioManager audioManager;

    private void Start()
    {
        spawner = GetComponentInParent<Spawner>();

        health = GetComponent<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health.isDead)
        {
            Debug.Log("Enemy is dead!");
        } else
        {
            Vector2 nextPosition = spawner.positions[currentIndex];
            Vector2 currentPosition = transform.position;

            Vector2 directionToNextPos = nextPosition - currentPosition;
            directionToNextPos.Normalize();

            Move(directionToNextPos);

            if ((currentPosition - nextPosition).magnitude < threshold)
            {
                currentIndex++;
                Flip();
                if (currentIndex >= spawner.positions.Count)
                {
                    currentIndex = 0;
                }
            }
        }
    }

    private void Move(Vector2 direction)
    {
        transform.position = transform.position + new Vector3(direction.x, direction.y) * speed * Time.deltaTime;
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }
}
