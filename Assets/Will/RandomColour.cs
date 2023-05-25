using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColour : MonoBehaviour
{    
    void Start()
    {
        GetComponent<SpriteRenderer>().material.color = Random.ColorHSV();
    }
}
