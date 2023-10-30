using System.Collections;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private CharacterModel model;
    [SerializeField] private float damage;
    [SerializeField] private float damageRate;

    [SerializeField] private IDamageble mob;

    public int GetCharacterIndex() => model.GetCharacterIndex();
    public Sprite GetCharacterSprite() => model.GetCharacterSprite();
    public string GetCharacterType() => model.GetCharacterType();
    public string GetCharacterPowerType() => model.GetChracterPowerType(); 
    public float GetCurrentDamage() => damage;
    public float GetCurrentDamageRate() => damageRate;

    public void SetCharacterModel(CharacterModel model) => this.model = model; 

    private void OnEnable()
    {
        SpawnerMobsController.instantiatedMob += SetMob;
    }

    private void OnDisable()
    {
        SpawnerMobsController.instantiatedMob -= SetMob;
    }

    public void SetMob(GameObject mob)
    {
        if (mob.TryGetComponent<IDamageble>(out this.mob))
            this.mob = mob.GetComponent<IDamageble>();
    }

    private void Start()
    {
        damage = model.GetDamage();
        damageRate = model.GetDamageRate();
        StartCoroutine(DamageMob());
    }

    private IEnumerator DamageMob()
    {
        while (true)
        {
            mob.TakeDemage(damage);
            yield return new WaitForSeconds(damageRate);
        }
    }
}
