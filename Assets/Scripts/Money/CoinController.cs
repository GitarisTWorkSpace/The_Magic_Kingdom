using System.Collections;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    [SerializeField] private CoinModel coinModel;
    [SerializeField] private float timeSave;

    private void Start()
    {
        coinModel.LoadCoinCount();
        //StartCoroutine(AutoSaveCoinCount());
    }

    public void AddCoin(int coinCount)
    {
        if (coinCount <= 0) return;
        coinModel.SetCoinCount(coinCount);
        PlayerPrefs.SetInt("CoinCount", coinModel.GetCoinCount());
    }

    public void SubstractCoin(int coinCount)
    {
        if (coinCount > coinModel.GetCoinCount()) return;
        coinModel.SetCoinCount(-coinCount);
        PlayerPrefs.SetInt("CoinCount", coinModel.GetCoinCount());
    }

    //private IEnumerator AutoSaveCoinCount()
    //{
    //    Debug.Log("�������� ������ �� �����");
    //    while (true)
    //    {
    //        PlayerPrefs.SetInt("CoinCount", coinModel.GetCoinCount());
    //        Debug.Log("�������� ������");
    //        yield return new WaitForSeconds(timeSave);           
    //    }
    //}
}
