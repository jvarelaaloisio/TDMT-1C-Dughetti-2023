using UnityEngine;

//TODO: TP2 - Fix - There should only be one Health component, this must be merged with PlayerHealth
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 30f;
    private float health;
    public bool isDamaged = false;
    public bool isDead = false;

    // Animation
    private float timer = 0f;
    private float timeIsDamaged = 0.5f;
    private float timeIsDead = 2f;

    // Audio
    [SerializeField] private CharacterAudioManager audioManager;

    //Particle
    [SerializeField] private new ParticleSystem particleSystem;

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
        
        Debug.Log($"Enemy got hit! Health: {health}");
        if (health <= 0f)
        {
            isDead = true;
            timer = timeIsDead;
            audioManager.PlayCharacterDeath();
            particleSystem.Play();
        }
        else
        {
            isDamaged = true;
            timer = timeIsDamaged;
            audioManager.PlayCharacterDamage();
            particleSystem.Play();
        }
    }
}
