using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnd : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text _timerText;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Stop the timer
        GameManager.Instance.StopTimer();
        
        // Get the timer value
        float timer = GameManager.Instance.GetTimer();

        // Display timer to player in M:SS.FF format
        _timerText.text = string.Format("{0}:{1:00}.{2:00}", Mathf.Floor(timer / 60), Mathf.Floor(timer) % 60, Mathf.Floor((timer * 100) % 100));

        // Reset the timer
        GameManager.Instance.ResetTimer();
    }
}
