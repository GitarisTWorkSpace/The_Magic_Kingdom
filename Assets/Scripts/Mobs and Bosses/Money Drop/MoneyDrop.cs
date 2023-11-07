using System;
using UnityEngine;

public class MoneyDrop : MonoBehaviour
{
    [SerializeField] private CristalController cristal;
    [SerializeField] private CoinController coin;
    [SerializeField] private GameObject coinSprite;
    [SerializeField] private GameObject cristalSprite;

    [SerializeField] private Vector2 xPositionSpawn;
    [SerializeField] private Vector2 yPositionSpawn;

    public static Action<int> ñhangedCoinText;
    public static Action<int> changedCristalText;

    public void DropCoin(int minCoinValue, int maxCoinValue, float multiplyCoinValue)
    {    
        int rndCoinAmount = GetRandomAmountMoney(minCoinValue, maxCoinValue);
        rndCoinAmount = MultiplyAmountMoney(rndCoinAmount, multiplyCoinValue);

        if (rndCoinAmount == 0) return;

        int spawnCoinAmount = 0;
        if (rndCoinAmount >= 100) spawnCoinAmount = rndCoinAmount / 100;
        if (rndCoinAmount < 100) spawnCoinAmount = rndCoinAmount / 20;
        if (spawnCoinAmount >= 15) spawnCoinAmount = 15;

        SpawnCountItemOfMoney(spawnCoinAmount, coinSprite);

        coin.AddCoin(rndCoinAmount);

        ñhangedCoinText?.Invoke(rndCoinAmount);
    }

    public void DropCristal(float chanse, int minCristalValue, int maxCristalValue, float multiplyCristalValue)
    {        
        float chanseRnd = UnityEngine.Random.Range(1f, 100f);
        if(chanseRnd <= chanse)
        {
            int rndCristalAmount = GetRandomAmountMoney(minCristalValue, maxCristalValue);
            rndCristalAmount = MultiplyAmountMoney(rndCristalAmount, multiplyCristalValue);

            int spawnCristalAmount = rndCristalAmount;
            if (spawnCristalAmount >= 15) spawnCristalAmount = 15;

            SpawnCountItemOfMoney(spawnCristalAmount, cristalSprite);

            cristal.AddCristals(rndCristalAmount);

            changedCristalText?.Invoke(rndCristalAmount);
        }
    }

    private int GetRandomAmountMoney(int minValue, int maxValue) => UnityEngine.Random.Range(minValue, maxValue);

    private int MultiplyAmountMoney(int rndAmount, float multiplier)
    {
        if (rndAmount != 0 && multiplier != 0)
            return (int)Mathf.Round(rndAmount * multiplier);

        return rndAmount;
    }

    private Vector3 SetRandomPosition()
    {
        float randomX = UnityEngine.Random.Range(xPositionSpawn.x, xPositionSpawn.y);
        float randomY = UnityEngine.Random.Range(yPositionSpawn.x, yPositionSpawn.y);
        Vector3 whereToSpawn = new Vector3(randomX, randomY, 2f);
        return whereToSpawn;
    }

    private void SpawnCountItemOfMoney(int count, GameObject prefab)
    {
        for (int i = 0; i < count; i++)
        {
            Instantiate(prefab, SetRandomPosition(), Quaternion.identity);
        }
    }
}
