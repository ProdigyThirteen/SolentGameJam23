using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switchable : MonoBehaviour
{
    public bool startActive = false;

    public void Toggle()
    {
        // Toggle the object's active state
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
