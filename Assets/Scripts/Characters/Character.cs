using System.Collections;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private CharacterModel model;
    [SerializeField] private float damage;
    [SerializeField] private float damageRate;
    [SerializeField] private int positionIndex;

    private Mob mob;

    public int GetCharacterIndex() => model.GetCharacterIndex();
    public Sprite GetCharacterSprite() => model.GetCharacterSprite();
    public string GetCharacterType() => model.GetCharacterType();
    public string GetCharacterPowerType() => model.GetChracterPowerType(); 
    public float GetCurrentDamage() => damage;
    public float GetCurrentDamageRate() => damageRate;
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
    }

    private void OnDisable()
    {
        SpawnerMobsController.instantiatedMob -= SetMob;
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
