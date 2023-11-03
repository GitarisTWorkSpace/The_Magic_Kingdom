using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MobView : MonoBehaviour
{
    [SerializeField] private Image mobSprite;
    [SerializeField] private Image bossSprite;
    [SerializeField] private Slider mobHealthBar;
    [SerializeField] private Animation animationShaking;

    [SerializeField] private TMP_Text healthPointText;
    [SerializeField] private TMP_Text dropCristalChanceText;
    [SerializeField] private TMP_Text maxCoinDropText;
    [SerializeField] private TMP_Text maxCristalDropText;

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
        if (this.mob.GetMobType() == "Boss")
        {
            mobSprite.gameObject.SetActive(false);
            bossSprite.gameObject.SetActive(true);
            
            bossSprite.sprite = this.mob.GetSprite();
            bossSprite.transform.position.Set(0, -150, 0);
        }
        else
        {
            bossSprite.gameObject.SetActive(false);
            mobSprite.gameObject.SetActive(true);
            mobSprite.sprite = this.mob.GetSprite();
        }
        dropCristalChanceText.text = this.mob.GetCristalChanceDrop().ToString() + "%";
        maxCoinDropText.text = this.mob.GetMaxCoinAmount().ToString();
        maxCristalDropText.text = this.mob.GetMaxCristalAmount().ToString();
    }

    public void ShakeMob()
    {
        animationShaking.Play();
    }

    private void Update()
    {
        if(mob != null)
        {
            mobHealthBar.value = mob.GetHealth();
            healthPointText.text = string.Format("{0}/{1}", mob.GetHealth().ToString(), mob.GetMaxHealth());
        }
    }
}
