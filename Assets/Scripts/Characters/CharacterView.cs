using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterView : MonoBehaviour
{
    [SerializeField] private CharacterUpgradeController upgradeController;
    [SerializeField] private CoinModel coinModel;

    [Header("Имя пероснажа")]
    [SerializeField] private TMP_Text characterNameText;

    [Header("Изображение персонажа")]
    [SerializeField] private Image characterImage;

    [Header("Тип пероснажа")]
    [SerializeField] private Image[] characterTypeImages;
    [SerializeField] private Sprite[] charactersTypeSprites;

    [Header("Тип Силы пероснажа")]
    [SerializeField] private Image[] characterPowerTypeImages;
    [SerializeField] private Sprite[] charactersPowerTypeSprites;

    [Header("Уровень пероснажа")]
    [SerializeField] private TMP_Text characterLvl;

    [Header("Кол-во опыта пероснажа")]
    [SerializeField] private Slider characterLevelPoint;

    [Header("Кнопка улучшения пероснажа")]
    [SerializeField] private Image characterUpgradeButtonImage;
    [SerializeField] private Sprite[] characterUpgradeButtonSprites;

    [Header("Кол-во монет для улучшения пероснажа")]
    [SerializeField] private TMP_Text coinNeedToUpgradeCharcterText;

    [Header("Урон пероснажа")]
    [SerializeField] private TMP_Text characterDamage;

    [Header("Скорость атаки пероснажа")]
    [SerializeField] private TMP_Text characterDamageRate;

    [Header("Способности пероснажа")]
    [SerializeField] private TMP_Text characterAbilitiOne;
    [SerializeField] private TMP_Text characterAbilitiTwo;
    [SerializeField] private TMP_Text CharacterAbilitiThree;

    private CharacterModel characterModel;

    public void OpenCharacterProfile(CharacterModel model)
    {
        characterModel = model;
        upgradeController.SetCharacterModel(model);

        characterNameText.text = characterModel.GetCharacterName();

        characterImage.sprite = characterModel.GetCharacterSprite();

        for (int i = 0; i < characterTypeImages.Length; i++)
            SelectSpriteCharacterType(characterTypeImages[i], i);

        for (int i = 0; i < characterPowerTypeImages.Length; i++)
            SelectSpriteCharacterPowerType(characterPowerTypeImages[i], i);

        characterLvl.text = characterModel.GetCharacterLevel().ToString();

        characterLevelPoint.maxValue = characterModel.GetNeedLevelPoint();
        characterLevelPoint.value = characterModel.GetCurrentLevelPoint();

        characterUpgradeButtonImage.sprite = characterUpgradeButtonSprites[1];
        if (characterModel.CanUpgradeCharacter() && characterModel.GetAmountMoneyToUpgrade() <= coinModel.GetCoinCount())
            characterUpgradeButtonImage.sprite = characterUpgradeButtonSprites[0];

        coinNeedToUpgradeCharcterText.text = characterModel.GetAmountMoneyToUpgrade().ToString();

        characterDamage.text = characterModel.GetDamage().ToString();
        characterDamageRate.text = characterModel.GetDamageRate().ToString();

        characterAbilitiOne.text = characterModel.GetAbilitieDescriptionByIndex(0);
        characterAbilitiTwo.text = characterModel.GetAbilitieDescriptionByIndex(1);
        CharacterAbilitiThree.text = characterModel.GetAbilitieDescriptionByIndex(2);
    }

    private void OnEnable()
    {
        CharacterModel.characterUpgraded += UpdateInfo;
    }

    private void OnDisable()
    {
        CharacterModel.characterUpgraded -= UpdateInfo;
    }

    private void UpdateInfo()
    {
        characterLvl.text = characterModel.GetCharacterLevel().ToString();

        characterLevelPoint.maxValue = characterModel.GetNeedLevelPoint();
        characterLevelPoint.value = characterModel.GetCurrentLevelPoint();

        characterUpgradeButtonImage.sprite = characterUpgradeButtonSprites[1];
        if (characterModel.CanUpgradeCharacter() && characterModel.GetAmountMoneyToUpgrade() <= coinModel.GetCoinCount())
            characterUpgradeButtonImage.sprite = characterUpgradeButtonSprites[0];

        coinNeedToUpgradeCharcterText.text = characterModel.GetAmountMoneyToUpgrade().ToString();
    }

    private void SelectSpriteCharacterType(Image img, int index)
    {
        if (characterModel.GetCharacterAllType().Length != 0)
        {
            img.gameObject.SetActive(false);
            if (index > characterModel.GetCharacterAllType().Length - 1) return;
            EntityType type = characterModel.GetCharacterAllType()[index];
            if (type == EntityType.Human)
            {
                img.gameObject.SetActive(true);
                img.sprite = charactersTypeSprites[0];
            }
            if (type == EntityType.Monster)
            {
                img.gameObject.SetActive(true);
                img.sprite = charactersTypeSprites[1];
            }
            if (type == EntityType.Spirit)
            {
                img.gameObject.SetActive(true);
                img.sprite = charactersTypeSprites[2];
            }
        }
    }

    private void SelectSpriteCharacterPowerType(Image img, int index)
    {
        if (characterModel.GetChracterAllPowerType().Length != 0)
        {            
            img.gameObject.SetActive(false);
            if (index > characterModel.GetChracterAllPowerType().Length - 1) return;
            EntityPowerType type = characterModel.GetChracterAllPowerType()[index];
            if (type == EntityPowerType.Natural)
            {
                img.gameObject.SetActive(true);
                img.sprite = charactersPowerTypeSprites[0];
            }
            if (type == EntityPowerType.Ice)
            {
                img.gameObject.SetActive(true);
                img.sprite = charactersPowerTypeSprites[1];
            }
            if (type == EntityPowerType.Fire)
            {
                img.gameObject.SetActive(true);
                img.sprite = charactersPowerTypeSprites[2];
            }
            if (type == EntityPowerType.Dark)
            {
                img.gameObject.SetActive(true);
                img.sprite = charactersPowerTypeSprites[3];
            }
            if (type == EntityPowerType.Light)
            {
                img.gameObject.SetActive(true);
                img.sprite = charactersPowerTypeSprites[4];
            }
            if (type == EntityPowerType.Cristal)
            {
                img.gameObject.SetActive(true);
                img.sprite = charactersPowerTypeSprites[5];
            }
        }
    }
}
