using UnityEngine;

public class CristalController : MonoBehaviour
{
    [SerializeField] private CristalModel cristalModel;

    public void AddCristals(int cristalCount)
    {
        if (cristalCount <= 0) return;
        cristalModel.SetCristalCount(cristalCount);
    }

    public void SubstractCristals(int cristalCount)
    {
        if (cristalCount > cristalModel.GetCristalCount()) return;
        cristalModel.SetCristalCount(-cristalCount);
    }
}
