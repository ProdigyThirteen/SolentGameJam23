using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;

    [Header("Menu Music")]
    [SerializeField] private AudioClip menuMusic;

    [Header("Button Sounds")]
    [SerializeField] private AudioClip buttonHover;
    [SerializeField] private AudioClip buttonSelect;
    [SerializeField] private AudioClip buttonBack;

    [Header("Player Sounds")]
    [SerializeField] private AudioClip playerPlacement;
    [SerializeField] private AudioClip playerAcceptance;
    [SerializeField] private AudioClip playerMovement;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != null)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public void PlayMusic(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.clip = clip;
        sfxSource.PlayOneShot(clip);
    }

    public void PlaySFXRandomPitch(AudioClip clip)
    {
        sfxSource.clip = clip;
        sfxSource.pitch = Random.Range(0.9f, 1.1f);
        sfxSource.PlayOneShot(clip);
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }

    public void PlayMenuMusic()
    {
        PlayMusic(menuMusic);
    }

    #region Button Sounds

    public void PlayButtonHover()
    {
        PlaySFX(buttonHover);
    }

    public void PlayButtonSelect()
    {
        PlaySFX(buttonSelect);
    }

    public void PlayButtonBack()
    {
        PlaySFX(buttonBack);
    }

    #endregion

    #region Player Sounds

    public void PlayPlayerPlacement()
    {
        PlaySFXRandomPitch(playerPlacement);
    }

    public void PlayPlayerAcceptance()
    {
        PlaySFXRandomPitch(playerAcceptance);
    }

    public void PlayPlayerCancellation()
    {
        PlaySFX(playerAcceptance);
    }

    public void PlayPlayerMovement()
    {
        PlaySFXRandomPitch(playerMovement);
    }

    public void PlayPlayerPickup()
    {
        PlaySFXRandomPitch(playerAcceptance);
    }

    #endregion

}
