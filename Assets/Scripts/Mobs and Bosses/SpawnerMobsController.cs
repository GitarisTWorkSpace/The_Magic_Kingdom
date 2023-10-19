using UnityEngine;

public class SpawnerMobsController : MonoBehaviour
{
    [Header("Ojects")]
    [SerializeField] private GameController gameController;
    [SerializeField] private MoneyDrop drop;
    [SerializeField] private Mob mobPrefab;
    [SerializeField] private MobModel[] mobList;
    private Mob mob;

    private void Start()
    {
        SpawnMobs();
    }

    private void SpawnMobs()
    {
        int index = Random.Range(0, mobList.Length);
        mobPrefab.drop = drop;
        mobPrefab.mobModel = mobList[index];
        mob = Instantiate(mobPrefab, this.transform, true);
        gameController.SetMob(mob.gameObject);
    }

    private void Update()
    {
        if (gameObject.transform.childCount == 0)
        {
            SpawnMobs();
        }
    }
}
