using System.Collections;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] private CristalModel cristalModel;
    [SerializeField] private CristalController cristalController;

    [SerializeField] private CoinModel coinModel;
    [SerializeField] private CoinController coinController;

    [SerializeField] private SpawnerMobsController spawnerMobsController;
    [SerializeField] private MobModel cristalCrate;
    [SerializeField] private MobModel coinCrate;

    [SerializeField] private GameObject AdsPanel;
    [SerializeField] private float adsTime;
    [SerializeField] private Button closeAdsButton;
    [SerializeField] private Image closeAdsButtonImage;
    [SerializeField] private Sprite[] closeAdsSpriteButton;

    [SerializeField] private AdviceView advice;

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
        StartCoroutine(Ads());
        if (typeMobSpawn == "Cristal")
            spawnerMobsController.SetNeededMob(cristalCrate, 3);
        else if (typeMobSpawn == "Coin")
            spawnerMobsController.SetNeededMob(coinCrate, 5);
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

    private IEnumerator Ads()
    {
        AdsPanel.SetActive(true);
        advice.SetAdviceText();
        closeAdsButton.interactable = false;
        closeAdsButtonImage.sprite = closeAdsSpriteButton[0];
        spawnerMobsController.GetCurrenMob().GetComponent<Mob>().CanTakeDamage = false;
        yield return new WaitForSeconds(adsTime);
        spawnerMobsController.GetCurrenMob().GetComponent<Mob>().CanTakeDamage = true;
        closeAdsButtonImage.sprite = closeAdsSpriteButton[1];
        closeAdsButton.interactable = true;
    }
}
