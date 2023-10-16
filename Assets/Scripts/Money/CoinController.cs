using UnityEngine;

public class CoinController : MonoBehaviour
{
    [SerializeField] private CoinModel coinModel;

    public void AddCoin(int coinCount)
    {
        if (coinCount <= 0) return;
        coinModel.SetCoinCount(coinCount);
    }

    public void SubstractCoin(int coinCount)
    {
        if (coinCount > coinModel.GetCoinCount()) return;
        coinModel.SetCoinCount(-coinCount);
    }
}
