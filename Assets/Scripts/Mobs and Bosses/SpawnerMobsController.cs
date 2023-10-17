using UnityEngine;

public class SpawnerMobsController : MonoBehaviour
{
    [Header("Ojects")]
    [SerializeField] private GameController gameController;
    [SerializeField] private Mob mobObject;
    [SerializeField] private MobModel[] mobList;
    private Mob mob;

    private void Start()
    {
        SpawnMobs();
    }

    private void SpawnMobs()
    {
        int index = Random.Range(0, mobList.Length);
        mobObject.mobModel = mobList[index];
        mob = Instantiate(mobObject, this.transform, true);
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
