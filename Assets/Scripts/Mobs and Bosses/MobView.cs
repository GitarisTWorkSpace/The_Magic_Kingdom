using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MobView : MonoBehaviour
{
    [SerializeField] private Image mobSprite;
    [SerializeField] private Image bossSprite;
    [SerializeField] private Slider mobHealthBar;
    [SerializeField] private Animation animationShaking;
    [SerializeField] private Animation bossAnimationShaking;
    [SerializeField] private AnimationClip[] bossGetDamage;

    private Mob mob;

    private void OnEnable()
    {
        SpawnerMobsController.instantiatedMob += SetMobInfo;
        Mob.takedDamage += ShakeMob;
    }

    private void OnDisable()
    {
        SpawnerMobsController.instantiatedMob -= SetMobInfo;
        Mob.takedDamage -= ShakeMob;
    }

    public void SetMobInfo(GameObject mob)
    {
        this.mob = mob.GetComponent<Mob>();
        mobHealthBar.maxValue = this.mob.GetMaxHealth();

        bossSprite.gameObject.SetActive(false);
        mobSprite.gameObject.SetActive(true);
        mobSprite.sprite = this.mob.GetSprite();

        if (this.mob.GetMobAllType()[0] == EntityType.Boss)
        {
            mobSprite.gameObject.SetActive(false);
            bossSprite.gameObject.SetActive(true);

            bossSprite.sprite = this.mob.GetSprite();
            bossSprite.transform.position.Set(0, -150, 0);
        }            
    }

    public void ShakeMob(int damage)
    {
        if (this.mob.GetMobAllType()[0] != EntityType.Boss)
            animationShaking.Play();

        //if (damage < 5)
        //{
        //    bossAnimationShaking.Stop();
        //}
        //else if (damage >= 5 && damage < 15)
        //{
        //    bossAnimationShaking.clip = bossGetDamage[0];
        //}
        //else if (damage >= 15 && damage < 30)
        //{
        //    bossAnimationShaking.clip = bossGetDamage[1];
        //}
        //else if (damage >= 30)
        //{
        //    bossAnimationShaking.clip = bossGetDamage[2];
        //}

        bossAnimationShaking.clip = bossGetDamage[1];
        if (this.mob.GetMobAllType()[0] == EntityType.Boss)
            bossAnimationShaking.Play();
    }

    private void Update()
    {
        if(mob != null)
        {
            mobHealthBar.value = mob.GetHealth();
        }
    }
}
