using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switchable : MonoBehaviour
{
    public bool startActive = false;

    private void Start()
    {
        StartCoroutine(DelayedStart());
    }

    public void Toggle()
    {
        // Toggle the object's active state
        gameObject.SetActive(!gameObject.activeSelf);
    }

    IEnumerator DelayedStart()
    {
        yield return new WaitForSeconds(0.3f);
        gameObject.SetActive(startActive);
    }
}