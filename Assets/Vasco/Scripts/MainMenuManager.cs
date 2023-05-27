using Newtonsoft.Json.Bson;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    [Header("Menus")]
    [SerializeField] private List<Menu> menus = new List<Menu>();

    [Header("Level Select")]
    [SerializeField] private List<LevelSO> levels = new List<LevelSO>();
    [SerializeField] private LevelCard levelCardPrefab;
    [SerializeField] private Transform levelSelect;

    [Header("Background")]
    [SerializeField] private GameObject BackgroundImage;

    [Header("Sounds")]
    [SerializeField] private AudioClip menuMusic;
    [SerializeField] private AudioClip buttonHover;
    [SerializeField] private AudioClip buttonSelect;
    [SerializeField] private AudioClip buttonBack;

    private AudioSettings audioSettings;
    private VideoSettings videoSettings;

    private void Awake()
    {
        audioSettings = FindObjectOfType<AudioSettings>();
        videoSettings = FindObjectOfType<VideoSettings>();  
    }

    private void Start()
    {     
        SoundManager.Instance.PlayMusic(menuMusic);

        audioSettings.LoadVolumes();
        videoSettings.Initialize();

        if (SceneController.Instance.GetCurrentScene().name == "Main Menu")
            OpenMenu("Main Menu");
    }

    #region Button Sounds

    public void PlayButtonHover()
    {
        SoundManager.Instance.PlayButtonHover();
    }

    public void PlayButtonSelect() 
    { 
        SoundManager.Instance.PlayButtonSelect();
    }

    public void PlayButtonBack()
    {
        SoundManager.Instance.PlayButtonBack();
    }

    #endregion

    #region Buttons

    public void Play()
    {
        SceneController.Instance.LoadScene("Level 1");
    }

    public void Exit()
    {
        Application.Quit();
    }

    #endregion



    #region Menu Handling
    public void OpenMenu(string name)
    {
        foreach (var menu in menus)
        {
            if (menu.name == name)
                menu.Open();
            else
                menu.Close();
        }
    }

    public void CloseMenu(string name)
    {
        foreach (var menu in menus)
        {
            if (menu.name == name)
                menu.Close();
        }
    }
    #endregion
}
