using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "CristalModel", menuName = "Models/CristalModel", order = 1)]
public class CristalModel : ScriptableObject
{
    [SerializeField] private int cristalCount;

    public void SetCristalCount(int value)
    {
        cristalCount += value;
        if (cristalCount <= 0) cristalCount = 0;
    }

    public int GetCristalCount()
    {
        return cristalCount;
    }

    public void LoadCristalCount()
    {
        cristalCount = PlayerPrefs.GetInt("CristalCount", 0);
    }
}
