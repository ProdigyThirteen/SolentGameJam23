using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Events;


public class SceneController : MonoBehaviour
{
    public static SceneController Instance { get; private set; }

    private Scene currentScene;
    [SerializeField] private string currentSceneName;

    public UnityEvent onSceneChanged;

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

    public Scene GetCurrentScene() { return currentScene;}

    public void OnSceneChanged(Scene current, Scene next)
    {
        currentScene = next;
        currentSceneName = currentScene.name;
        onSceneChanged.Invoke();
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
