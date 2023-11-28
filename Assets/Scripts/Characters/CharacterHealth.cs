using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    //Delegates
    public delegate void OnCharacterDamage();
    public static OnCharacterDamage onCharacterDamage;
    public delegate void OnCharacterDeath();
    public static OnCharacterDeath onCharacterDeath;

    // Health
    [SerializeField] private float maxHealth = 100f;
    private float health;

    //Particle
    [SerializeField] private new ParticleSystem particleSystem;

    void Start()
    {
        health = maxHealth;
        onCharacterDamage += particleSystem.Play;
        onCharacterDeath += particleSystem.Play;
    }

    void Update()
    {
        
    }

    public float GetHealth()
    {
        return health;
    }

    public float GetMaxHealth()
    {
        return maxHealth;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log("Damage taken, current health: " + health);

        if (health <= 0)
        {
            //onCharacterDeath?.Invoke();
            Debug.Log("Dead");
        }
        else
        {
            //onCharacterDamage?.Invoke();
            Debug.Log("Damaged");
        }
    }
}
