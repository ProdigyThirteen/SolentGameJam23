using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "ScriptableObjects/Level", order = 1)]
public class LevelSO : ScriptableObject
{
    public int sceneIndex;
    public new string name;
    public Sprite image;
}
