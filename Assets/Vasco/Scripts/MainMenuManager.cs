using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
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

    [Header("Sound Clips")]
    [SerializeField] private AudioClip menuMusic;
    [SerializeField] private AudioClip buttonHover;
    [SerializeField] private AudioClip buttonSelect;
    [SerializeField] private AudioClip buttonBack;

    private void Awake()
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

    private void Start()
    {     
        SoundManager.Instance.PlayMusic(menuMusic);

        if (SceneController.Instance.GetCurrentScene().name == "Main Menu")
        {
            foreach (var menu in menus)
            {
                if(menu.name == "Main Menu")
                    menu.Open();
                else
                    menu.Close();
            }
        }
    }

    #region Button Sounds

    public void PlayButtonHover()
    {
        SoundManager.Instance.PlaySFX(buttonHover);
    }

    public void PlayButtonSelect()
    {
        SoundManager.Instance.PlaySFX(buttonSelect);
    }

    public void PlayButtonBack()
    {
        SoundManager.Instance.PlaySFX(buttonBack);
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
