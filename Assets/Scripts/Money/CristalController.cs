using System.Collections;
using UnityEngine;

public class CristalController : MonoBehaviour
{
    [SerializeField] private CristalModel cristalModel;
    [SerializeField] private float timeSave;

    private void Start()
    {
        cristalModel.LoadCristalCount();
        //StartCoroutine(AutoSaveCristalCount());
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

    //private IEnumerator AutoSaveCristalCount()
    //{
    //    Debug.Log("Сохранил Кристаллы до цикла");
    //    while (true)
    //    {
    //        PlayerPrefs.SetInt("CristalCount", cristalModel.GetCristalCount());
    //        Debug.Log("Сохранил Кристаллы");
    //        yield return new WaitForSeconds(timeSave);
    //    }
    //}
}
