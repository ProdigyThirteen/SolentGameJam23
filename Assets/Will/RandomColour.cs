using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColour : MonoBehaviour
{

    void Start()
    {

        Color green = new Color(0f, 1f, 0.4f);
        Color blue = new Color(0.3f, 0.85f, 1.0f);

        PlayerMovement playerScript = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();

        int maxSegments = GameManager.Instance.TotalSegments;
        int currentSegments = playerScript.getSegmentCount();

        float percent = (float) currentSegments/ (float) maxSegments;

        Debug.Log(percent);

        Color end_color = Color.Lerp(blue, green, percent);

        GetComponent<SpriteRenderer>().material.color = end_color;

    }
}
