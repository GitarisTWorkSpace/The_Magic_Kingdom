using System;
using System.Collections;
using UnityEngine;

public class Character : MonoBehaviour
{
    public static Action<int> characterAtacked;

    [SerializeField] private CharacterModel model;

    [SerializeField] private float currentDamage;
    [SerializeField] private float damageForMob;
    [SerializeField] private float currentDamageRate;

    [SerializeField] private int positionIndex;

    private Mob mob;

    public Sprite GetCharacterSprite() => model.GetCharacterSprite();
    public int GetCharacterIndex() => model.GetCharacterIndex();
    public EntityType[] GetCharacterAllType() => model.GetCharacterAllType();
    public EntityPowerType[] GetChracterAllPowerType() => model.GetChracterAllPowerType();
    public float GetCurrentDamage() => damageForMob;
    public float GetCurrentDamageRate() => currentDamageRate;
    public int GetPositionIndex() => positionIndex;

    public void SetCharacterModel(CharacterModel model) => this.model = model; 
    public void SetPositionIndex(int posititonIndex) => this.positionIndex = posititonIndex;

    public void SetMob(GameObject mob)
    {
        if (mob.TryGetComponent<Mob>(out this.mob))
            this.mob = mob.GetComponent<Mob>();
        damageForMob = currentDamage;
        ChangeCurrentDamage();
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
        model.LoadCharacterInfo();
        currentDamage = model.GetDamage();
        if (model.GetCharacterLevel() >= 10)
            currentDamage = model.GetDamage() * (model.GetCharacterLevel() / 10);
        damageForMob = currentDamage;
        ChangeCurrentDamage();
        currentDamageRate = model.GetDamageRate();
        StartCoroutine(DamageMob());
    }

    private IEnumerator DamageMob()
    {
        yield return new WaitForSeconds(currentDamageRate);
        while (true)
        {
            damageForMob = currentDamage;
            ChangeCurrentDamage();
            mob.TakeDemage(damageForMob);
            //model.UseAbilties();
            characterAtacked?.Invoke(positionIndex);
            yield return new WaitForSeconds(currentDamageRate);
            damageForMob = currentDamage;
            ChangeCurrentDamage();
        }
    }

    private void ChangeCurrentDamage()
    {
        if (model.GetChracterAllPowerType().Length <= 0) return;
        else
        {
            if (model.GetChracterAllPowerType()[0] == EntityPowerType.None) return;
            CheackCharacterAndMobPowerType(model.GetChracterAllPowerType()[0]);
        }
    }

    private void CheackCharacterAndMobPowerType(EntityPowerType characterPowerType)
    {
        if (characterPowerType == EntityPowerType.None) return;
        if (characterPowerType == EntityPowerType.Natural)
        {
            if (mob.GetMobAllPowerType().Length <= 0) return;
            else
            {
                if (mob.GetMobAllPowerType()[0] == EntityPowerType.Natural) return;
                else if (mob.GetMobAllPowerType()[0] == EntityPowerType.Ice) damageForMob += currentDamage / 4;
                else if (mob.GetMobAllPowerType()[0] == EntityPowerType.Fire) damageForMob -= currentDamage / 2;
                else if (mob.GetMobAllPowerType()[0] == EntityPowerType.Dark) damageForMob -= currentDamage / 2;
                else if (mob.GetMobAllPowerType()[0] == EntityPowerType.Light) damageForMob = 0;
                else if (mob.GetMobAllPowerType()[0] == EntityPowerType.Cristal) damageForMob += currentDamage / 2;
            }
        }
        else if (characterPowerType == EntityPowerType.Ice)
        {
            if (mob.GetMobAllPowerType().Length <= 0) return;
            else
            {
                if (mob.GetMobAllPowerType()[0] == EntityPowerType.Natural) damageForMob += currentDamage / 2;
                else if (mob.GetMobAllPowerType()[0] == EntityPowerType.Ice) return;
                else if (mob.GetMobAllPowerType()[0] == EntityPowerType.Fire) damageForMob = 0;
                else if (mob.GetMobAllPowerType()[0] == EntityPowerType.Dark) damageForMob += currentDamage / 4;
                else if (mob.GetMobAllPowerType()[0] == EntityPowerType.Light) damageForMob += currentDamage / 4;
                else if (mob.GetMobAllPowerType()[0] == EntityPowerType.Cristal) return;
            }
        }
        else if (characterPowerType == EntityPowerType.Fire)
        {
            if (mob.GetMobAllPowerType().Length <= 0) return;
            else
            {
                if (mob.GetMobAllPowerType()[0] == EntityPowerType.Natural) damageForMob += currentDamage / 2;
                else if (mob.GetMobAllPowerType()[0] == EntityPowerType.Ice) damageForMob += currentDamage / 2;
                else if (mob.GetMobAllPowerType()[0] == EntityPowerType.Fire) return;
                else if (mob.GetMobAllPowerType()[0] == EntityPowerType.Dark) damageForMob += currentDamage / 2;
                else if (mob.GetMobAllPowerType()[0] == EntityPowerType.Light) damageForMob -= currentDamage / 2;
                else if (mob.GetMobAllPowerType()[0] == EntityPowerType.Cristal) damageForMob -= currentDamage / 2;
            }
        }
        else if (characterPowerType == EntityPowerType.Dark)
        {
            if (mob.GetMobAllPowerType().Length <= 0) return;
            else
            {
                if (mob.GetMobAllPowerType()[0] == EntityPowerType.Natural) damageForMob += currentDamage / 4;
                else if (mob.GetMobAllPowerType()[0] == EntityPowerType.Ice) return;
                else if (mob.GetMobAllPowerType()[0] == EntityPowerType.Fire) damageForMob += currentDamage / 4;
                else if (mob.GetMobAllPowerType()[0] == EntityPowerType.Dark) damageForMob += currentDamage / 4;
                else if (mob.GetMobAllPowerType()[0] == EntityPowerType.Light) damageForMob = 0;
                else if (mob.GetMobAllPowerType()[0] == EntityPowerType.Cristal) return;
            }
        }
        else if (characterPowerType == EntityPowerType.Light)
        {
            if (mob.GetMobAllPowerType().Length <= 0) return;
            else
            {
                if (mob.GetMobAllPowerType()[0] == EntityPowerType.Natural) damageForMob = -(currentDamage / 4);
                else if (mob.GetMobAllPowerType()[0] == EntityPowerType.Ice) damageForMob += currentDamage / 4;
                else if (mob.GetMobAllPowerType()[0] == EntityPowerType.Fire) return;
                else if (mob.GetMobAllPowerType()[0] == EntityPowerType.Dark) damageForMob += currentDamage / 2;
                else if (mob.GetMobAllPowerType()[0] == EntityPowerType.Light) damageForMob = -(currentDamage / 4);
                else if (mob.GetMobAllPowerType()[0] == EntityPowerType.Cristal) damageForMob -= currentDamage / 4;
            }
        }
        else if (characterPowerType == EntityPowerType.Cristal)
        {
            if (mob.GetMobAllPowerType().Length <= 0) return;
            else
            {
                if (mob.GetMobAllPowerType()[0] == EntityPowerType.Natural) damageForMob -= currentDamage / 4;
                else if (mob.GetMobAllPowerType()[0] == EntityPowerType.Ice) damageForMob += currentDamage / 2;
                else if (mob.GetMobAllPowerType()[0] == EntityPowerType.Fire) damageForMob += currentDamage / 2;
                else if (mob.GetMobAllPowerType()[0] == EntityPowerType.Dark) return;
                else if (mob.GetMobAllPowerType()[0] == EntityPowerType.Light) damageForMob = 0;
                else if (mob.GetMobAllPowerType()[0] == EntityPowerType.Cristal) damageForMob = -(currentDamage / 4);
            }
        }
    }
}
