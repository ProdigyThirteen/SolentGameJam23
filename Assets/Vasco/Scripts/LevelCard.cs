using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelCard : MonoBehaviour
{
    [SerializeField] private Image levelImage;
    [SerializeField] private TMP_Text levelName;
    [SerializeField] private Button levelButton;

    public Image Image { get => levelImage; set => levelImage = value; }
    public TMP_Text Name { get => levelName; set => levelName = value; }
    public Button Button { get => levelButton; set => levelButton = value; }

}
