using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUDSegments : MonoBehaviour
{
    public static HUDSegments Instance;

    [SerializeField] private Image segmentIndicator;
    [SerializeField] private TMP_Text segmentQuantity;

    [SerializeField] private PlayerMovement playerMovement;


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if(!playerMovement.IsExtending())
        {
            segmentQuantity.enabled = false;
            segmentIndicator.enabled = false;
        }
        else
        {
            segmentQuantity.enabled = true;
            segmentIndicator.enabled = true;
            segmentQuantity.text = playerMovement.getRemainingSegments().ToString() + "/" + GameManager.Instance.TotalSegments;
        }
        

    }
}
