using UnityEngine;

public class CharacterAudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource characterAudioSource;

    [SerializeField] private AudioClip characterAttack;
    [SerializeField] private AudioClip characterDamage;
    [SerializeField] private AudioClip characterDeath;
    [SerializeField] private AudioClip characterJump;
    [SerializeField] private AudioClip characterSteps;

    // Character sounds config
    private float characterStepsTimer = 0f;
    private float characterStepsDelay = 0.3f;

    public void PlayCharacterAttack()
    {
        characterAudioSource.clip = characterAttack;
        characterAudioSource.Play();
    }

    public void PlayCharacterDamage()
    {
        characterAudioSource.clip = characterDamage;
        characterAudioSource.Play();
    }

    public void PlayCharacterDeath()
    {
        characterAudioSource.clip = characterDeath;
        characterAudioSource.Play();
    }

    public void PlayCharacterJump()
    {
        characterAudioSource.clip = characterJump;
        characterAudioSource.Play();
    }

    public void PlayCharacterSteps()
    {
        if (characterStepsTimer <= 0f)
        {
            characterAudioSource.clip = characterSteps;
            characterAudioSource.Play();
            characterStepsTimer = characterStepsDelay;
        }
        else
        {
            characterStepsTimer -= Time.deltaTime;
        }
    }
}
