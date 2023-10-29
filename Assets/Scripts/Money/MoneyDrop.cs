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

    public void DropCoin(int minCoinValue, int maxCoinValue, int multiplyCoinValue)
    {    
        int rndCoinCount = UnityEngine.Random.Range(minCoinValue, maxCoinValue);

        if (rndCoinCount != 0 && multiplyCoinValue != 0)
            rndCoinCount *= multiplyCoinValue;

        int amont = 0;
        if (rndCoinCount >= 100) amont = rndCoinCount / 100;
        if (rndCoinCount < 100) amont = rndCoinCount / 20;
        if (amont >= 15) amont = 15;

        for (int i = 0; i < amont; i++)
        {
            float randomX = UnityEngine.Random.Range(-1f, 1f);
            float randomY = UnityEngine.Random.Range(-1f, 1f);
            Vector3 whereToSpawn = new Vector3(randomX, randomY, 2f);
            Instantiate(coinSprite, whereToSpawn, Quaternion.identity);
        }

        coin.AddCoin(rndCoinCount);
        ñhangedCoinText?.Invoke(rndCoinCount);
    }

    public void DropCristal(float chanse, int minCristalValue, int maxCristalValue, int multiplyCristalValue)
    {        
        float chanseRnd = UnityEngine.Random.Range(1f, 100f);
        if(chanseRnd <= chanse)
        {
            int rndCristalCount = UnityEngine.Random.Range(minCristalValue, maxCristalValue);
            rndCristalCount *= multiplyCristalValue;

            for (int i = 0; i < rndCristalCount; i++)
            {
                float randomX = UnityEngine.Random.Range(-1f, 1f);
                Vector3 whereToSpawn = new Vector3(randomX, this.transform.position.y, 1f);
                Instantiate(cristalSprite, whereToSpawn, Quaternion.identity);
            }

            cristal.AddCristals(rndCristalCount);
            changedCristalText?.Invoke(rndCristalCount);
        }
    }
}
