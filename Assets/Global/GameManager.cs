using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int TotalSegments = 3;
    public int MaxSegments = 8;
    public bool StickyAcquired = false;

    // Speedrun timer
    private bool _timerActive = false;
    private float _timer = 0f;

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

        // Set the timer to active
        _timerActive = true;
    }

    public void Update()
    {
        _timer += Time.deltaTime;
    }

    public void ResetTimer()
    {
        _timer = 0f;
    }

    public float GetTimer()
    {
        return _timer;
    }

    public bool StopTimer()
    {
        return _timerActive = false;
    }

    
}
