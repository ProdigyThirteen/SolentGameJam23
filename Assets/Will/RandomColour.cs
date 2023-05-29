using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColour : MonoBehaviour
{

    void Start()
    {

        PlayerMovement playerScript = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();

        int maxSegments = GameManager.Instance.TotalSegments;
        int currentSegments = playerScript.getSegmentCount();
        Debug.Log(GetComponent<SpriteRenderer>().color);
        // GetComponent<SpriteRenderer>().color = new Color(0,255,0);

    }
}
