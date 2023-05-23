using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> menus = new List<GameObject>();

    private void Start()
    {
        foreach (GameObject menu in menus)
        {
            
            menu.SetActive(false);
        }
    }


}
