using UnityEngine;

public class SaveController : MonoBehaviour
{
    public static SaveController Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public void SaveData(string name, int data)
    {
        PlayerPrefs.SetInt(name,data);
    }

    public void SaveData(string name, string data)
    {
        PlayerPrefs.SetString(name,data);
    }

    public void SaveData(string name, float data)
    {
        PlayerPrefs.SetFloat(name,data);   
    }

    public int LoadDataInt(string name)
    {
        return PlayerPrefs.GetInt(name);
    }

    public string LoadDataString(string name)
    {
        return PlayerPrefs.GetString(name);
    }

    public float LoadDataFloat(string name)
    {
        return PlayerPrefs.GetFloat(name);
    }
}
