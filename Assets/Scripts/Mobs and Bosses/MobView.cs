using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MobView : MonoBehaviour
{
    [SerializeField] private Image mobSprite;
    [SerializeField] private Slider mobHealthBar;
    [SerializeField] private Animation animationShaking;
    [SerializeField] private TMP_Text healthPointText;

    private GameObject mob;

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
        if(mob != null)
        {
            mobHealthBar.value = mob.GetComponent<Mob>().GetHealth();
            healthPointText.text = string.Format("{0}/{1}", mob.GetComponent<Mob>().GetHealth().ToString(), mob.GetComponent<Mob>().GetMaxHealth());
        }
    }
}
