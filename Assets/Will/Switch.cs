using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    // List of objects to be enabled when the switch is activated
    public List<GameObject> ObjectsToEnable = new List<GameObject>();

    // List of objects to be disabled when the switch is activated
    public List<GameObject> ObjectsToDisable = new List<GameObject>();

    // List of objects to toggle when the switch is activated
    public List<GameObject> ObjectsToToggle = new List<GameObject>();

    private void Start()
    {
        // Loop through all objects to enable and disable
        foreach (GameObject obj in ObjectsToEnable)
        {
            // Disable the object
            obj.SetActive(false);
        }
    }


    // Called when the switch is activated
    public void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object that collided with the switch is the player
        if (other.CompareTag("Player"))
        {
            // Loop through all objects to enable
            foreach (GameObject obj in ObjectsToEnable)
            {
                // Enable the object
                obj.SetActive(true);
            }

            // Loop through all objects to disable
            foreach (GameObject obj in ObjectsToDisable)
            {
                // Disable the object
                obj.SetActive(false);
            }
        }

        // Loop through all objects to toggle
        foreach (GameObject obj in ObjectsToToggle)
        {
            // Toggle the object
            obj.SetActive(!obj.activeSelf);
        }
    }
}
