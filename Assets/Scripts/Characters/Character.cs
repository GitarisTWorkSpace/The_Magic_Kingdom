using System;
using System.Collections;
using UnityEngine;

public class Character : MonoBehaviour
{
    public static Action<int> characterAtacked;

    [SerializeField] private CharacterModel model;

    [SerializeField] private float currentDamage;
    [SerializeField] private float currentDamageRate;

    [SerializeField] private int positionIndex;

    private Mob mob;

    public Sprite GetCharacterSprite() => model.GetCharacterSprite();
    public int GetCharacterIndex() => model.GetCharacterIndex();
    public EntityType[] GetCharacterAllType() => model.GetCharacterAllType();
    public EntityPowerType[] GetChracterAllPowerType() => model.GetChracterAllPowerType();
    public float GetCurrentDamage() => currentDamage;
    public float GetCurrentDamageRate() => currentDamageRate;
    public int GetPositionIndex() => positionIndex;

    public void SetCharacterModel(CharacterModel model) => this.model = model; 
    public void SetPositionIndex(int posititonIndex) => this.positionIndex = posititonIndex;

    public void SetMob(GameObject mob)
    {
        if (mob.TryGetComponent<Mob>(out this.mob))
            this.mob = mob.GetComponent<Mob>();
    }

    private void OnEnable()
    {
        SpawnerMobsController.instantiatedMob += SetMob;
        Mob.mobDead += AddLevelPoint;
    }

    private void OnDisable()
    {
        SpawnerMobsController.instantiatedMob -= SetMob;
        Mob.mobDead -= AddLevelPoint;
    }   

    private void AddLevelPoint()
    {
        model.AddCurrentLevelPoint(mob.GetMobDropCountLevelPoints());
    }

    private void Start()
    {
        //model.LoadCharacterInfo();
        currentDamage = model.GetDamage();
        if (model.GetCharacterLevel() >= 10)
            currentDamage = model.GetDamage() * (model.GetCharacterLevel() / 10);
        currentDamageRate = model.GetDamageRate();
        StartCoroutine(DamageMob());
    }

    private IEnumerator DamageMob()
    {
        yield return new WaitForSeconds(currentDamageRate);
        while (true)
        {
            mob.TakeDemage(currentDamage);
            //model.UseAbilties();
            characterAtacked?.Invoke(positionIndex);
            yield return new WaitForSeconds(currentDamageRate);
        }
    }
}
