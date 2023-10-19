using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MobView : MonoBehaviour
{
    [SerializeField] private Image mobSprite;
    [SerializeField] private Slider mobHealthBar;
    [SerializeField] private Animation animationShaking;

    private GameObject mob;

    private void OnEnable()
    {
        SpawnerMobsController.instantiatedMob += SetMobInfo;
    }

    private void OnDisable()
    {
        SpawnerMobsController.instantiatedMob -= SetMobInfo;
    }

    public void SetMobInfo(GameObject mob)
    {
        this.mob = mob;
        mobHealthBar.maxValue = this.mob.GetComponent<Mob>().GetMaxHealth();
        mobSprite.sprite = this.mob.GetComponent<Mob>().GetSprite();
    }

    public void ShakeMob()
    {
        animationShaking.Play();
    }

    private void Update()
    {
        if(mob != null) mobHealthBar.value = mob.GetComponent<Mob>().GetHealth();
    }
}
