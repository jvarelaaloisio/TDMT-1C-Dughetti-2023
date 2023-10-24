using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 30f;
    private float health;
    public bool isDamaged = false;
    public bool isDead = false;

    private float timer = 0f;
    private float timeIsDamaged = 1f;

    private void Start()
    {
        health = maxHealth;
    }

    private void Update()
    {
        if (isDamaged)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                Debug.Log("Enemy stop damaged anim!");
                timer = 0f;
                isDamaged = false;
            }
        } else if (isDead)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        timer = timeIsDamaged;
        Debug.Log($"Enemy got hit! Health: {health}");
        if (health <= 0f)
        {
            isDead = true;
            Debug.Log("Health is 0!");
        }
        else
        {
            isDamaged = true;
        }
    }
}
