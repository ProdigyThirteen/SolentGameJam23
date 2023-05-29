using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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

    [Header("Shake")]
    public float shakeWarning = 1.5f;
    public float shakeTime = 0.5f;
    private Vector3 _originalPos;


    private void Start()
    {

        playerScript = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
        _originalPos = platform.transform.position;

    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > looping_time)
            timer = 0;

        // Platform shaking
        if (timer > active_end - shakeWarning)
        {
            StartCoroutine(PlatformShake());
        }

        if (active_start <= timer && timer <= active_end)
        {

            platform.SetActive(true);
            enabled = true;
            platform.transform.position = _originalPos;

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

    IEnumerator PlatformShake()
    {
        float distance = 0.014f;
        Vector3 leftPos = new Vector3(platform.transform.position.x - distance, platform.transform.position.y, platform.transform.position.z);
        Vector3 rightPos = new Vector3(platform.transform.position.x + distance, platform.transform.position.y, platform.transform.position.z);

        while (timer > active_end - shakeWarning)
        {
            // Lerp to left
            platform.transform.position = Vector3.Lerp(platform.transform.position, leftPos, 0.5f);
            yield return new WaitForSeconds(0.05f);

            // Lerp to right
            platform.transform.position = Vector3.Lerp(platform.transform.position, rightPos, 0.5f);
            yield return new WaitForSeconds(0.05f);
        }
    }
}
