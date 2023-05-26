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

        //Not in use
        //LoadLevelSelect();   
    }

    private void Start()
    {     
        SoundManager.Instance.PlayMusic(menuMusic);

        audioSettings.LoadVolumes();
        videoSettings.Initialize();

        if (SceneController.Instance.GetCurrentScene().name == "Main Menu")
            OpenMenu("Main Menu");
    }


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

    private void LoadLevelSelect()
    {
        foreach (var level in levels)
        {
            LevelCard levelCard = Instantiate(levelCardPrefab, levelSelect);

            levelCard.Name.text = level.name;
            levelCard.Image.sprite = level.image;

            levelCard.Button.onClick.AddListener(() =>
            {
                SceneController.Instance.LoadScene(level.sceneIndex);

            });
        }
    }
    #endregion
}
