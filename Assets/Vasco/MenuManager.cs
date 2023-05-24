using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance { get; private set; }

    [SerializeField] private List<Menu> menus = new List<Menu>();

    [SerializeField] private GameObject BackgroundImage;

    [SerializeField] private bool isPaused;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    private void Start()
    {     
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

    private void Update()
    {
        if(SceneController.Instance.GetCurrentScene().name != "Main Menu")
        {
            BackgroundImage.SetActive(false);
  
            if (Input.GetKeyDown(KeyCode.Escape) && isPaused == false)
            {
                Debug.Log("TEST");
                OpenMenu("Pause Menu");
                isPaused = true;
            }
            else
            {
                CloseMenu("Pause Menu");
                isPaused = false;
            }


        }
            
    }

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

    public void CloseAllMenus()
    {
        if (SceneController.Instance.GetCurrentScene().name == "Main Menu")
            return; 

        foreach (var menu in menus)
        {
            menu.Close();
        }
    }

}
