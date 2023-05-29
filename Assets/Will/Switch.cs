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
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // If the player collides with the switch, toggle the switchable objects
        if (other.CompareTag("Player"))
        {
            foreach (GameObject switchableObject in switchableObjects)
            {
                // switchableObject.SetActive(!switchableObject.activeSelf);
                switchableObject.GetComponent<Switchable>().Toggle();
            }
        }
    }
}