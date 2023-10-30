using UnityEngine;

[CreateAssetMenu(fileName = "Mob", menuName = "Models/Mob")]
public class MobModel : ScriptableObject
{
    [SerializeField] private Sprite mobSprite;
    [SerializeField] private float health;

    [SerializeField] private string type;
    [SerializeField] private string powerType;

    [Header("Cristal")]
    [SerializeField] private float cristalChanceDrop;
    [SerializeField] private int minCristalValue;
    [SerializeField] private int maxCristalValue;
    [SerializeField] private float multiplyCristalValue;

    [Header("Coin")]
    [SerializeField] private int minCoinValue;
    [SerializeField] private int maxCoinValue;
    [SerializeField] private float multiplyCoinValue;

    public float GetHealth() => health;
    public string GetMobType() => type;
    public string GetMobPowerType() => powerType;
    public Sprite GetSprite() => mobSprite;
    public float GetCristalChanceDrop() => cristalChanceDrop;
    public int GetMinCristalValue() => minCristalValue;
    public int GetMaxCristalValue() => maxCristalValue;
    public float GetMultiplyCristalValue() => multiplyCristalValue;
    public int GetMinCoinValue() => minCoinValue;
    public int GetMaxCoinValue() => maxCoinValue;
    public float GetMultiplyCoinValue() => multiplyCoinValue;

}
