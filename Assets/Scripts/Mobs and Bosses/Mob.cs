using UnityEngine;

public class Mob : MonoBehaviour, IDamageble
{
    [SerializeField] public MobModel mobModel;
    [SerializeField] private float health;

    private void Start()
    {
        health = mobModel.GetHealth();
    }

    public void TakeDemage(float damage)
    {
        if (damage < 0) return;
        health -= damage;
    }

    public Sprite GetSprite()
    {
        return mobModel.GetSprite();
    }

    public float GetHealth() 
    {
        return health; 
    }

    private void Update()
    {
        if (health <= 0) Destroy(gameObject);
    }
}