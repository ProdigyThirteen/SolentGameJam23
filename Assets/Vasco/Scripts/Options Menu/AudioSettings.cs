using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    [Header("Audio Mixer")]
    [SerializeField] private AudioMixer audioMixer;

    [Header("Sliders")]
    [SerializeField] private Slider masterVolumeSlider;
    [SerializeField] private Slider musicVolumeSlider;
    [SerializeField] private Slider sfxVolumeSlider;

    public void Initialize()
    {
        LoadVolumes();
    }

    public void SetVolume(Slider slider)
    {
        audioMixer.SetFloat(slider.name, Mathf.Log10(slider.value) * 20);
        PlayerPrefs.SetFloat(slider.name + "Volume", slider.value);
    }

    private void LoadVolumes()
    {
        masterVolumeSlider.value = PlayerPrefs.GetFloat("MasterVolume",1);
        musicVolumeSlider.value = PlayerPrefs.GetFloat("MusicVolume",1);
        sfxVolumeSlider.value = PlayerPrefs.GetFloat("SfxVolume", 1);

        SetVolume(masterVolumeSlider);
        SetVolume(musicVolumeSlider);
        SetVolume(sfxVolumeSlider);
    }

}
