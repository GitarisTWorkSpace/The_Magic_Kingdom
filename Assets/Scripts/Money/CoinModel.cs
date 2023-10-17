using UnityEngine;

[CreateAssetMenu(fileName = "CoinModel", menuName = "Models/CoinModel", order = 1)]
public class CoinModel : ScriptableObject
{
    [SerializeField] private int coinCount;

    public void SetCoinCount(int value)
    {
        coinCount += value;
        if(coinCount <= 0) coinCount = 0;
    }

    public int GetCoinCount()
    {
        return coinCount;
    }

    public void LoadCoinCount()
    {
        coinCount = PlayerPrefs.GetInt("CoinCount");
    }
}
