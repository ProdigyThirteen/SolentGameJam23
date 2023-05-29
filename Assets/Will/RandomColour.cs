using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColour : MonoBehaviour
{

    void Start()
    {

        Color green = new Color(34.0f, 177.0f, 76.0f, 1.0f);
        Color blue = new Color(76.0f, 226.0f, 255.0f, 1.0f);

        PlayerMovement playerScript = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();

        int maxSegments = GameManager.Instance.TotalSegments;
        int currentSegments = playerScript.getSegmentCount();

        float percent = 0.5f;

        

        Color end_color = Color.Lerp(green, green, percent);

        GetComponent<SpriteRenderer>().material.color = new Color(0,0.5f,0);
        Debug.Log(GetComponent<SpriteRenderer>().material.color);

    }
}
