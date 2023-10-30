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

    public void DropCoin(int minCoinValue, int maxCoinValue, float multiplyCoinValue)
    {    
        float rndCoinCount = UnityEngine.Random.Range(minCoinValue, maxCoinValue);

        if (rndCoinCount != 0 && multiplyCoinValue != 0)
            rndCoinCount *= multiplyCoinValue;

        int amont = 0;
        if (rndCoinCount >= 100) amont = (int)Mathf.Round(rndCoinCount / 100);
        if (rndCoinCount < 100) amont = (int)Mathf.Round(rndCoinCount / 20);
        if (amont >= 15) amont = 15;

        for (int i = 0; i < amont; i++)
        {
            float randomX = UnityEngine.Random.Range(-1f, 1f);
            float randomY = UnityEngine.Random.Range(-1f, 1f);
            Vector3 whereToSpawn = new Vector3(randomX, randomY, 2f);
            Instantiate(coinSprite, whereToSpawn, Quaternion.identity);
        }

        coin.AddCoin((int)Mathf.Round(rndCoinCount));
        ñhangedCoinText?.Invoke((int)Mathf.Round(rndCoinCount));
    }

    public void DropCristal(float chanse, int minCristalValue, int maxCristalValue, float multiplyCristalValue)
    {        
        float chanseRnd = UnityEngine.Random.Range(1f, 100f);
        if(chanseRnd <= chanse)
        {
            float rndCristalCount = UnityEngine.Random.Range(minCristalValue, maxCristalValue);
            rndCristalCount *= multiplyCristalValue;

            for (int i = 0; i < (int)Mathf.Round(rndCristalCount); i++)
            {
                float randomX = UnityEngine.Random.Range(-1f, 1f);
                Vector3 whereToSpawn = new Vector3(randomX, this.transform.position.y, 1f);
                Instantiate(cristalSprite, whereToSpawn, Quaternion.identity);
            }

            cristal.AddCristals((int)Mathf.Round(rndCristalCount));
            changedCristalText?.Invoke((int)Mathf.Round(rndCristalCount));
        }
    }
}
