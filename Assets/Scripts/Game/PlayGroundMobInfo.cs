using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayGroundMobInfo : MonoBehaviour
{
    [SerializeField] private SpawnerMobsController mobSpawnController;

    [SerializeField] private Sprite[] TypeSprites;
    [SerializeField] private Sprite[] PowerTypeSprites;

    [SerializeField] private TMP_Text healthPointText;

    [SerializeField] private TMP_Text dropCristalChanceText;
    [SerializeField] private TMP_Text maxCoinDropText;
    [SerializeField] private TMP_Text maxCristalDropText;

    [SerializeField] private Image[] mobTypeImages;
    [SerializeField] private Image[] mobPowerTypeImages;

    private Mob mob;

    private void SetMob()
    {
        if (mobSpawnController.GetCurrenMob() == null)
            return;
        mob = mobSpawnController.GetCurrenMob().GetComponent<Mob>();

        dropCristalChanceText.text = mob.GetCristalChanceDrop().ToString() + "%";
        maxCoinDropText.text = mob.GetMaxCoinAmount().ToString();
        maxCristalDropText.text = mob.GetMaxCristalAmount().ToString();

        for (int i = 0; i < mobTypeImages.Length; i++)
            SelectSpriteMobType(mobTypeImages[i], i);

        for (int i = 0; i < mobPowerTypeImages.Length; i++)
            SelectSpriteMobPowerType(mobPowerTypeImages[i], i);
    }

    private void SelectSpriteMobType(Image img, int index)
    {
        if (mob.GetMobAllType().Length >= 0)
        {
            img.gameObject.SetActive(false);
            if (index > mob.GetMobAllType().Length - 1) return;
            EntityType type = mob.GetMobAllType()[index];
            if (type == EntityType.Human)
            {
                img.gameObject.SetActive(true);
                img.sprite = TypeSprites[0];
            }
            if (type == EntityType.Monster)
            {
                img.gameObject.SetActive(true);
                img.sprite = TypeSprites[1];
            }
            if (type == EntityType.Spirit)
            {
                img.gameObject.SetActive(true);
                img.sprite = TypeSprites[2];
            }
            if (type == EntityType.Boss)
            {
                img.gameObject.SetActive(true);
                img.sprite = TypeSprites[3];
            }
        }
    }

    private void SelectSpriteMobPowerType(Image img, int index)
    {
        if (mob.GetMobAllPowerType().Length >= 0)
        {
            img.gameObject.SetActive(false);
            if (index > mob.GetMobAllPowerType().Length - 1) return;
            EntityPowerType type = mob.GetMobAllPowerType()[index];
            if (type == EntityPowerType.Natural)
            {
                img.gameObject.SetActive(true);
                img.sprite = PowerTypeSprites[0];
            }
            if (type == EntityPowerType.Ice)
            {
                img.gameObject.SetActive(true);
                img.sprite = PowerTypeSprites[1];
            }
            if (type == EntityPowerType.Fire)
            {
                img.gameObject.SetActive(true);
                img.sprite = PowerTypeSprites[2];
            }
            if (type == EntityPowerType.Dark)
            {
                img.gameObject.SetActive(true);
                img.sprite = PowerTypeSprites[3];
            }
            if (type == EntityPowerType.Light)
            {
                img.gameObject.SetActive(true);
                img.sprite = PowerTypeSprites[4];
            }
            if (type == EntityPowerType.Cristal)
            {
                img.gameObject.SetActive(true);
                img.sprite = PowerTypeSprites[5];
            }
        }
    }

    private void Update()
    {
        if (mob != null)
        {
            healthPointText.text = string.Format("{0}/{1}", mob.GetHealth().ToString(), mob.GetMaxHealth());
        }

        if (mob == null)
            SetMob();        
    }
}
