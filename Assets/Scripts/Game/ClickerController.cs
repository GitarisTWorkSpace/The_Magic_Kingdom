using UnityEngine;

public class ClickerController : MonoBehaviour
{
    [SerializeField] private MobView mobView;
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
        mob.GetComponent<IDamageble>().TakeDemage(damageToMob);
        mobView.ShakeMob();
    }
}
