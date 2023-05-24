using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    [SerializeField] private List<LevelSO> levels = new List<LevelSO>();

    [SerializeField] private GameObject levelButton;
    [SerializeField] private Transform levelSelect;

    private void Awake()
    {
        foreach (var level in levels)
        {
            GameObject button = Instantiate(levelButton, levelSelect);

            button.GetComponentInChildren<TMP_Text>().text = level.levelName;
            //TODO level image,button sound,etc

            button.GetComponent<Button>().onClick.AddListener(() =>
            {
                SceneController.Instance.LoadScene(level.sceneIndex);
            });

        }
    }


}
