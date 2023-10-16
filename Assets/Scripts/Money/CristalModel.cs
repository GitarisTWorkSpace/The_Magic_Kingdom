using UnityEngine;

[CreateAssetMenu(fileName = "CristalModel", menuName = "Models/CristalModel", order = 1)]
public class CristalModel : ScriptableObject
{
    [SerializeField] private int cristalCount;

    public void SetCristalCount(int value)
    {
        cristalCount += value;
    }

    public int GetCristalCount()
    {
        return cristalCount;
    }
}
