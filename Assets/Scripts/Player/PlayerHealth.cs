using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Health
    [SerializeField] public float maxHealth = 100f;
    public float health;

    //Animation parameters
    public bool isDamaged = false;
    public bool isDead = false;
    private float timer = 0f;
    private float timeIsDamaged = 0.5f;
    private float timeIsDead = 2f;

    //Audio
    [SerializeField] private CharacterAudioManager audioManager;

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

        if (health <= 0)
        {
            timer = timeIsDead;
            isDead = true;
            audioManager.PlayCharacterDeath();
        } else
        {
            timer = timeIsDamaged;
            isDamaged = true;
            audioManager.PlayCharacterDamage();
        }
    }
}
