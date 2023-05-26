using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    [Header("Options")]
    [Tooltip("List of all the option menus. Default is always the first entry.")]
    [SerializeField] private List<GameObject> optionMenu = new List<GameObject>();

    [SerializeField] private GameObject lastSelected;

    [SerializeField] private Button videoSettingsButton;
    [SerializeField] private Button audioSettingsButton;

    public void Awake()
    {    
        videoSettingsButton.onClick.AddListener(() => OpenMenu("Video"));
        audioSettingsButton.onClick.AddListener(() => OpenMenu("Audio"));

        lastSelected = optionMenu[0];
    }

    private void Start()
    {
        OpenLastSelected();
    }

    private void OnEnable()
    {
        OpenLastSelected();
    }

    #region Options Open/Closing

    public void OpenMenu(string name)
    {
        foreach (var menu in optionMenu)
        {
            if (menu.name == name)
            {
                menu.gameObject.SetActive(true);

                lastSelected = menu;

                if(menu.name == "Video")
                    videoSettingsButton.Select();
                else
                    audioSettingsButton.Select();
            }           
            else
                menu.gameObject.SetActive(false);
        }
    }

    public void OpenLastSelected()
    {
        foreach (var menu in optionMenu)
        {
            if (menu.name == lastSelected.name)
            {
                menu.gameObject.SetActive(true);

                lastSelected = menu;

                if (menu.name == "Video")
                    videoSettingsButton.Select();
                else
                    audioSettingsButton.Select();
            }
            else
                menu.gameObject.SetActive(false);
        }
    }

    #endregion
}
