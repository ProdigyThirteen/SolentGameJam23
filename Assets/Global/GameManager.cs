using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int TotalSegments = 3;
    public const int MaxSegments = 8;

    public void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Debug.LogError("There is more than one GameManager in the scene!");
            Destroy(gameObject);
        }
    }
}
