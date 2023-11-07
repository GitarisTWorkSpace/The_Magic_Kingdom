using UnityEngine;

public class ClickerController : MonoBehaviour
{
    [SerializeField] private float damageToMob;
    private GameObject mob;

    private void OnEnable()
    {
        SpawnerMobsController.instantiatedMob += SetMob;
    }

    private void OnDisable()
    {
        SpawnerMobsController.instantiatedMob -= SetMob;
    }

    private void SetMob(GameObject mob)
    {
        this.mob = mob;
    }

    public void DamageToMob()
    {
        damageToMob = 5f;
        if (mob.GetComponent<Mob>().GetMobAllType().Length > 0)
            if (mob.GetComponent<Mob>().GetMobAllType()[0] == EntityType.Boss)
                damageToMob = 500f;
        mob.GetComponent<IDamageble>().TakeDemage(damageToMob);
    }
}
