using UnityEngine;

public class CharacterUpgradeController : MonoBehaviour
{
    [SerializeField] private CharacterModel model;

    [SerializeField] private CoinController coinController;
    [SerializeField] private CoinModel coinModel;

    public void SetCharacterModel(CharacterModel model) => this.model = model;

    public void UpgareCharacter()
    {
        if (coinModel.GetCoinCount() >= model.GetAmountMoneyToUpgrade() && model.CanUpgradeCharacter())
        {
            coinController.SubstractCoin(model.GetAmountMoneyToUpgrade());
            model.UpgareCharacter();
        }
    }
}
