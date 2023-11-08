using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private CristalModel cristalModel;
    [SerializeField] private CristalController cristalController;

    [SerializeField] private CoinModel coinModel;
    [SerializeField] private CoinController coinController;

    [SerializeField] private SpawnerMobsController spawnerMobsController;
    [SerializeField] private MobModel cristalCrate;
    [SerializeField] private MobModel coinCrate;

    [SerializeField] private CharacterModel[] charactersModel;
    public void BuyCoinForCristal(int purchaseAmounMoney)
    {
        int cristalValue = purchaseAmounMoney / 1000;
        if (cristalModel.GetCristalCount() >= cristalValue)
        {
            cristalController.SubstractCristals(cristalValue);
            coinController.AddCoin(purchaseAmounMoney);
        }
    }

    public void BuyCristalForCoin(int purchaseAmounMoney)
    {
        int coinValue = purchaseAmounMoney * 1000;
        if (coinModel.GetCoinCount() >= coinValue)
        {
            coinController.SubstractCoin(coinValue);
            cristalController.AddCristals(purchaseAmounMoney);
        }
    }

    public void BuyMobSpawn(string typeMobSpawn)
    {
        if (typeMobSpawn == "Cristal")
        {
            spawnerMobsController.SetNeededMob(cristalCrate, 4);
        }
        else if (typeMobSpawn == "Coin")
        {
            spawnerMobsController.SetNeededMob(coinCrate, 4);
        }
    }

    public void BuyCharacterLevelPoints(int cristalValue)
    {
        if (cristalModel.GetCristalCount() >= cristalValue)
        {
            cristalController.SubstractCristals(cristalValue);
            foreach (var character in charactersModel)
            {
                character.AddCurrentLevelPoint(100);
            }
        }
    }
}
