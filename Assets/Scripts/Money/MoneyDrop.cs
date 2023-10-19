using System;
using UnityEngine;

public class MoneyDrop : MonoBehaviour
{
    [SerializeField] private CristalController cristal;
    [SerializeField] private CoinController coin;
    [SerializeField] private GameObject coinSprite;
    [SerializeField] private GameObject cristalSprite;

    public static Action<int> ñhangedCoinText;
    public static Action<int> changedCristalText;

    public void DropCoin()
    {
        int rndCoinCount = UnityEngine.Random.Range(15, 1000);
        //int amont = 0;
        //if (rndCoinCount >= 100) amont = rnd / 50;
        //if (rndCoinCount < 100) amont = rnd / 10;
        coin.AddCoin(rndCoinCount);
        ñhangedCoinText?.Invoke(rndCoinCount);
    }

    public void DropCristal(int chanse)
    {        
        int chanseRnd = UnityEngine.Random.Range(1, 100);
        if(chanseRnd <= chanse)
        {
            int rndCristalCount = UnityEngine.Random.Range(1, 3);
            cristal.AddCristals(rndCristalCount);
            changedCristalText?.Invoke(rndCristalCount);
        }
    }
}
