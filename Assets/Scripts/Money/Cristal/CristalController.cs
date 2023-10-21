using UnityEngine;

public class CristalController : MonoBehaviour
{
    [SerializeField] private CristalModel cristalModel;
    [SerializeField] private float timeSave;

    private void Start()
    {
        cristalModel.LoadCristalCount();
    }

    public void AddCristals(int cristalCount)
    {
        if (cristalCount <= 0) return;
        cristalModel.SetCristalCount(cristalCount);
        PlayerPrefs.SetInt("CristalCount", cristalModel.GetCristalCount());
    }

    public void SubstractCristals(int cristalCount)
    {
        if (cristalCount > cristalModel.GetCristalCount()) return;
        cristalModel.SetCristalCount(-cristalCount);
        PlayerPrefs.SetInt("CristalCount", cristalModel.GetCristalCount());
    }

    public void ResetCristal()
    {
        cristalModel.SetCristalCount(-cristalModel.GetCristalCount());
        PlayerPrefs.SetInt("CristalCount", cristalModel.GetCristalCount());
    }
}
