using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // If the player collides with the switch, toggle the switchable objects
        if (other.CompareTag("Player"))
        {
            //foreach (GameObject switchableObject in SwitchingObjectManager.Instance.switchableObjects)
            //{
            //    // switchableObject.SetActive(!switchableObject.activeSelf);
            //    switchableObject.GetComponent<Switchable>().Toggle();
            //}

            SwitchingObjectManager.Instance.SwitchObjects();
        }
    }
}