using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEditor;

public class SceneController : MonoBehaviour
{
    public static SceneController Instance;

    private Scene currentScene;
    [SerializeField] private string currentSceneName;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.activeSceneChanged += OnSceneChanged;
        }
        else Destroy(gameObject);
    }

    private void OnSceneChanged(Scene current, Scene next)
    {
        currentScene = next;
        currentSceneName = currentScene.name;
    }

    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }


    public void ExitGame()
    {
        Application.Quit();
    }

}
