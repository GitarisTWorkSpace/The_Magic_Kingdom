using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "Models/Character")]
public class CharacterModel : ScriptableObject
{
    public static Action characterUpgraded;

    [SerializeField] private Sprite characterSprite;
    [SerializeField] private int characterIndex;

    [SerializeField] private string characterName;

    [SerializeField] private int characterLevel;
    [SerializeField] private int needCharacterLevelPointValueToUpgtade;
    [SerializeField] private int currentCharacterLevelPointValueToUgrade;

    [SerializeField] private UpgradeAmountMoneyModel upgradeModel;

    [SerializeField] private EntityType[] type;
    [SerializeField] private EntityPowerType[] powerType;

    [SerializeField] private float damage;
    [SerializeField] private float damageRate;

    [SerializeField] private AbilitiesModel[] abilities;

    public Sprite GetCharacterSprite() => characterSprite;
    public int GetCharacterIndex() => characterIndex;

    public string GetCharacterName() => characterName;

    public int GetCharacterLevel() => characterLevel;
    public int GetNeedLevelPoint() => needCharacterLevelPointValueToUpgtade;
    public int GetCurrentLevelPoint() => currentCharacterLevelPointValueToUgrade;

    public bool CanUpgradeCharacter() => currentCharacterLevelPointValueToUgrade >= needCharacterLevelPointValueToUpgtade;

    public int GetAmountMoneyToUpgrade() => upgradeModel.GetAmounMoneyToUpgradeCharacter(characterLevel);

    public EntityType[] GetCharacterAllType() => type;
    public EntityPowerType[] GetChracterAllPowerType() => powerType;
    public float GetDamage() => characterLevel >= 20 ? damage * (characterLevel / 10) : damage;

    public float GetDamageRate() => damageRate;

    public string GetAbilitieDescriptionByIndex(int index) => abilities[index].GetAbilitiDescription();

    public void AddCurrentLevelPoint(int value)
    {
        currentCharacterLevelPointValueToUgrade += value;
        PlayerPrefs.SetInt(characterIndex + "LVLPoints", currentCharacterLevelPointValueToUgrade);
    }

    public void UseAbilties()
    {
        foreach(var abiliti in abilities)
        {
            Debug.Log(characterName);
            abiliti.Abiliti();
        }
    }

    public void UpgareCharacter()
    {
        if (characterLevel >= 50) return;
        currentCharacterLevelPointValueToUgrade -= needCharacterLevelPointValueToUpgtade;
        characterLevel++;
        PlayerPrefs.SetInt(characterIndex.ToString() + "LVL", characterLevel);
        PlayerPrefs.GetInt(characterIndex.ToString() + "LVLPoints", 0);
        characterUpgraded?.Invoke();
    }

    public void LoadCharacterInfo()
    {
        characterLevel = PlayerPrefs.GetInt(characterIndex.ToString() + "LVL", 1);
        currentCharacterLevelPointValueToUgrade = PlayerPrefs.GetInt(characterIndex.ToString() + "LVLPoints", 0);
    }
}
