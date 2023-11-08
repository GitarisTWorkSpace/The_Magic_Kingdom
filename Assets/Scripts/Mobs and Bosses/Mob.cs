using System;
using UnityEngine;

public class Mob : MonoBehaviour, IDamageble
{
    [SerializeField] public MobModel mobModel;
    [SerializeField] public MoneyDrop drop;
    [SerializeField] private float health;

    public static Action<int> takedDamage;

    public Sprite GetSprite() => mobModel.GetSprite();
    public float GetHealth() => health;
    public float GetMaxHealth() => mobModel.GetHealth();
    public float GetCristalChanceDrop() => mobModel.GetCristalChanceDrop();
    public int GetMaxCoinAmount() => (int)Mathf.Round(mobModel.GetMaxCoinValue() * mobModel.GetMultiplyCoinValue());
    public int GetMaxCristalAmount() => (int)Mathf.Round(mobModel.GetMaxCristalValue() * mobModel.GetMultiplyCristalValue());
    public int GetMobDropCountLevelPoints() => mobModel.GetMobDropCountLevelPoints();
    public EntityType[] GetMobAllType() => mobModel.GetMobAllType();
    public EntityPowerType[] GetMobAllPowerType() => mobModel.GetMobAllPowerType();

    public void TakeDemage(float damage)
    {
        if (damage < 0) return;
        health -= damage;
        takedDamage?.Invoke((int)damage);
    }

    private void Start()
    {
        health = mobModel.GetHealth();
    } 

    private void Update()
    {
        if (health <= 0)
        {
            drop.DropCoin(mobModel.GetMinCoinValue(), mobModel.GetMaxCoinValue(), mobModel.GetMultiplyCoinValue());
            drop.DropCristal(mobModel.GetCristalChanceDrop(), mobModel.GetMinCristalValue(), mobModel.GetMaxCristalValue(), mobModel.GetMultiplyCristalValue());
            Destroy(gameObject); 
        }
    }
}
