using System.Collections;
using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    // Animation
    private bool isDamaged = false;
    private bool isDead = false;
    [SerializeField] CharacterView characterView;
    [SerializeField] CharacterAudioManager characterAudioManager;

    // Health
    [SerializeField] private float maxHealth = 100f;
    private float health;

    //Particle
    [SerializeField] private new ParticleSystem particleSystem;

    private void Start()
    {
        health = maxHealth;
    }

    public bool GetIsDamaged()
    {
        return isDamaged;
    }

    public bool GetIsDead()
    {
        return isDead;
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

        particleSystem.Play();

        if (health <= 0)
        {
            isDead = true;
            characterAudioManager.PlayCharacterDeath();
            StartCoroutine(CheckDeathAnimation());
        }
        else
        {
            isDamaged = true;
            characterAudioManager.PlayCharacterDamage();
            StartCoroutine(CheckHitAnimation());
        }
    }

    IEnumerator CheckHitAnimation()
    {
        yield return new WaitUntil(() => characterView.IsCurrentAnimationDamage());
        yield return new WaitUntil(() => !characterView.IsAnimationBeingPlayed());
        isDamaged = false;
    }

    IEnumerator CheckDeathAnimation()
    {
        yield return new WaitUntil(() => characterView.IsCurrentAnimationDeath());
        yield return new WaitUntil(() => !characterView.IsAnimationBeingPlayed());
        Destroy(gameObject);
    }
}
