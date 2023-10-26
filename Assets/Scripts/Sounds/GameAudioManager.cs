using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource ambienceAudioSource;
    [SerializeField] private AudioSource musicAudioSource;

    [SerializeField] private AudioClip ambience;
    [SerializeField] private AudioClip musicBossFight;
    [SerializeField] private AudioClip musicRegular;

    private float musicDuration = 60f;
    private float musicDelay = 0;

    private void Update()
    {
        if (musicDelay <= 0)
        {
            Debug.Log("Play music!");
            PlayMusicRegular();
            musicDelay = musicDuration;
        } else
        {
            musicDelay -= Time.deltaTime;
        }
            
    }

    public void PlayAmbienceSound()
    {
        ambienceAudioSource.clip = ambience;
        ambienceAudioSource.Play();
    }

    public void PlayMusicBossFight()
    {
        ambienceAudioSource.clip = musicBossFight;
        musicAudioSource.Play();
    }

    public void PlayMusicRegular()
    {
        ambienceAudioSource.clip = musicRegular;
        musicAudioSource.Play();
    }
}
