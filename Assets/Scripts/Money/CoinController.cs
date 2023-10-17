using UnityEngine;

public class CoinController : MonoBehaviour
{
    [SerializeField] private CoinModel coinModel;
    [SerializeField] private float timeSave;

    private void Start()
    {
        coinModel.LoadCoinCount();
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

    public void ResetCoins()
    {
        coinModel.SetCoinCount(-coinModel.GetCoinCount());
        PlayerPrefs.SetInt("CoinCount", coinModel.GetCoinCount());
    }
}
