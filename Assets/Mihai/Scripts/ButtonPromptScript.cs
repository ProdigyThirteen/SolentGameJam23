using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPromptScript : MonoBehaviour
{

    public GameObject tooltip;


    private void Start()
    {
        tooltip.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.gameObject.tag == "Player")
            tooltip.SetActive(true);

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            tooltip.SetActive(false);

    }


}
