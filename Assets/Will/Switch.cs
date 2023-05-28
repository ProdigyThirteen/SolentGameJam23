using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    private GameObject[] switchableObjects;

    public void Start()
    {
        // Find all objects with the tag "Switchable" and add them to the list
        switchableObjects = GameObject.FindGameObjectsWithTag("Switchable");

        // If the switch is set to start active, toggle the switchable objects
        foreach (GameObject switchableObject in switchableObjects)
        {
            if (!switchableObject.GetComponent<Switchable>().startActive)
            {
                switchableObject.GetComponent<Switchable>().Toggle();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // If the player collides with the switch, toggle the switchable objects
        if (other.CompareTag("Player"))
        {
            foreach (GameObject switchableObject in switchableObjects)
            {
                switchableObject.GetComponent<Switchable>().Toggle();
            }
        }
    }
}
