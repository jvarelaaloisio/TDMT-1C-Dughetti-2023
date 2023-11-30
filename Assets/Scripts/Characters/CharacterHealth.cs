using System.Collections;
using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    // Animation
    private bool isDamaged = false;
    private bool isDead = false;
    [SerializeField] CharacterView characterView;

    // Boss mechanics
    [SerializeField] private bool isBoss = false;
    [SerializeField] private BossSpecialAttack bossSpecialAttack;

    // Health
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private bool isPlayerCharacter = false;
    private float health;
    private bool isImmuneToDamage = false;

    // Level Handler
    [SerializeField] private LevelHandler levelHandler;

    // Particle
    [SerializeField] private new ParticleSystem particleSystem;

    // Sound
    [SerializeField] CharacterAudioManager characterAudioManager;

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

    public bool GetIsImmuneToDamage()
    {
        return isImmuneToDamage;
    }

    public void SetIsImmuneToDamage(bool value)
    {
        isImmuneToDamage = value;
    }

    public void TakeDamage(float damage)
    {
        if (!isImmuneToDamage)
        {
            health -= damage;
            Debug.Log("Damage taken, current health: " + health);
        } else
        {
            Debug.Log("Damage immunity is enabled, player won't take damage");
        }

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

        if (isBoss)
        {
            Debug.Log("Starting special attack coroutine");
            bossSpecialAttack.SpecialAttackCoroutine();
        }
    }

    IEnumerator CheckDeathAnimation()
    {
        Debug.Log("Starting Death coroutine");
        yield return new WaitUntil(() => characterView.IsCurrentAnimationDeath());
        yield return new WaitUntil(() => !characterView.IsAnimationBeingPlayed());

        if (isPlayerCharacter)
            levelHandler.GameOver();
        else
            gameObject.SetActive(false);
    }
}
