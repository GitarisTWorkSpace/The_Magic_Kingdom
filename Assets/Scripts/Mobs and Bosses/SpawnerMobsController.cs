using System;
using UnityEngine;

public class SpawnerMobsController : MonoBehaviour
{
    [Header("Ojects")]
    [SerializeField] private MoneyDrop drop;
    [SerializeField] private Mob mobPrefab;
    [SerializeField] private MobModel[] mobList;
    private Mob mob;

    public static Action<GameObject> instantiatedMob;

    private void Start()
    {
        SpawnMobs();
    }

    private void SpawnMobs()
    {
        int index = UnityEngine.Random.Range(0, mobList.Length);
        mobPrefab.drop = drop;
        mobPrefab.mobModel = mobList[index];
        mob = Instantiate(mobPrefab, this.transform, true);
        instantiatedMob?.Invoke(mob.gameObject);
    }

    private void Update()
    {
        if (gameObject.transform.childCount == 0)
        {
            SpawnMobs();
        }
    }
}
