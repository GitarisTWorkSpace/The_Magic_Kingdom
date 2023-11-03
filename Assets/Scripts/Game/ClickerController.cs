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
        if (mob.GetComponent<Mob>().GetMobType() == "Boss")
            damageToMob = 500f;
        else damageToMob = 5f;
        mob.GetComponent<IDamageble>().TakeDemage(damageToMob);
    }
}
