using UnityEngine;

public class Mob : MonoBehaviour, IDamageble
{
    [SerializeField] public MobModel mobModel;
    [SerializeField] public MoneyDrop drop;
    [SerializeField] private float health;

    public Sprite GetSprite() => mobModel.GetSprite();
    public float GetHealth() => health;
    public float GetMaxHealth() => mobModel.GetHealth();

    public void TakeDemage(float damage)
    {
        if (damage < 0) return;
        health -= damage;
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
