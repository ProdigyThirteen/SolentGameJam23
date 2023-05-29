using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchingObjectManager : MonoBehaviour
{
    // Static instance
    public static SwitchingObjectManager Instance;

    public GameObject[] switchableObjects;

    public void Awake()
    {
        // Set the static instance
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Start()
    {
        // Find all objects with the tag "Switchable" and add them to the list
        switchableObjects = GameObject.FindGameObjectsWithTag("Switchable");
    }

    public void SwitchObjects()
    {
        // Toggle the switchable objects
        foreach (GameObject switchableObject in switchableObjects)
        {
            switchableObject.GetComponent<Switchable>().Toggle();
        }
    }

    public void RevertObjects()
    {
        // Check object active status versus start active status
        for (int i = 0; i < switchableObjects.Length; i++)
        {
            Switchable obj = switchableObjects[i].GetComponent<Switchable>();

            if (obj.GetActive() != obj.startActive)
            {
                obj.Toggle();
            }
        }
    }
}
