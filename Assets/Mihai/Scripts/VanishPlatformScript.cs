using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanishPlatformScript : MonoBehaviour
{
    float timer = 0.0f;
    bool enabled = true;

    public GameObject platform;
    PlayerMovement playerScript;

    public float active_start = 2.5f;
    public float active_end = 7.5f;
    public float looping_time = 10.0f;


    private void Start()
    {

        playerScript = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();

    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > looping_time)
            timer = 0;

        if(active_start <= timer && timer <= active_end)
        {

            platform.SetActive(true);
            enabled = true;

        }

        else
        {

            if(enabled)
            {
                enabled = false;
                platform.SetActive(false);
                checkForExtendingPlayer();

            }

        }

    }


    void checkForExtendingPlayer()
    {

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, 0.6f);


        if (hit.collider == null)
            return;

        if(hit.collider.gameObject == playerScript.getFirstSegment() && playerScript.IsExtending())
        {

            playerScript.forceCancel();

        }


    }
}
