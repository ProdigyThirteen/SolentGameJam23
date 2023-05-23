using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "ScriptableObjects/Level", order = 1)]
public class LevelSO : ScriptableObject
{
    public int sceneIndex;
    public string levelName;
    public string levelDescription;
    public Sprite levelImage;
}
