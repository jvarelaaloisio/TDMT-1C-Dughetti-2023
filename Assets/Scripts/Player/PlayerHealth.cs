using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] public float maxHealth = 100f;
    public float health;
    public bool isDamaged = false;
    public bool isDead = false;
    private float timer = 0f;
    private float timeIsDamaged = 0.5f;

    void Start()
    {
        health = maxHealth;
    }

    private void Update()
    {
        if (isDead)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                gameObject.SetActive(false);
            }
        } else if (isDamaged)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                Debug.Log("Player stop damaged anim!");
                timer = 0f;
                isDamaged = false;
            }
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        timer = timeIsDamaged;
        Debug.Log($"Player got hit! Health: {health}");
        if (health <= 0)
        {
            isDead = true;
            Debug.Log("Health is 0!");
        } else
        {
            isDamaged = true;
        }
    }
}
