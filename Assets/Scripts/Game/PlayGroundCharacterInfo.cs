using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayGroundCharacterInfo : MonoBehaviour
{
    [SerializeField] private BattleGroundController battleGroundController;

    [SerializeField] private int characterPosition;
    [SerializeField] private Character characterInPositon;

    [SerializeField] private GameObject infoOfCharacterPosition;

    [SerializeField] private Sprite[] TypeSprites;
    [SerializeField] private Sprite[] PowerTypeSprites;

    [Header("Тип пероснажа")]
    [SerializeField] private Image[] characterTypeImages;

    [Header("Тип Силы пероснажа")]
    [SerializeField] private Image[] characterPowerTypeImages;

    [Header("Урон пероснажа")]
    [SerializeField] private Sprite[] damagSprits;
    [SerializeField] private Image damageImage;
    [SerializeField] private TMP_Text characterDamage;

    [Header("Скорость атаки пероснажа")]
    [SerializeField] private TMP_Text characterDamageRate;

    private void Update()
    {
        SetCharacterInfoByIndex();
    }

    private void SetCharacterInfoByIndex()
    {
        if (battleGroundController.GetCharactersOnPlayGround(characterPosition) == null)
        {
            infoOfCharacterPosition.SetActive(false);
            return;
        }
        characterInPositon = battleGroundController.GetCharactersOnPlayGround(characterPosition).GetComponent<Character>();        

        infoOfCharacterPosition.SetActive(true);

        for (int i = 0; i < characterTypeImages.Length; i++)
            SelectSpriteCharacterType(characterTypeImages[i], i, characterPosition);

        for (int i = 0; i < characterPowerTypeImages.Length; i++)
            SelectSpriteCharacterPowerType(characterPowerTypeImages[i], i, characterPosition);


        if (characterInPositon.GetCurrentDamage() >= 0)
            damageImage.sprite = damagSprits[0];
        else
            damageImage.sprite = damagSprits[1];
        characterDamage.text = Mathf.Abs(characterInPositon.GetCurrentDamage()).ToString();
        characterDamageRate.text = characterInPositon.GetCurrentDamageRate().ToString();
    }

    private void SelectSpriteCharacterType(Image img, int index, int positionIndex)
    {
        if (characterInPositon.GetCharacterAllType().Length != 0)
        {
            img.gameObject.SetActive(false);
            if (index > characterInPositon.GetCharacterAllType().Length - 1) return;
            EntityType type = characterInPositon.GetCharacterAllType()[index];
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
        }
    }

    private void SelectSpriteCharacterPowerType(Image img, int index, int positionIndex)
    {
        if (characterInPositon.GetChracterAllPowerType().Length != 0)
        {
            img.gameObject.SetActive(false);
            if (index > characterInPositon.GetChracterAllPowerType().Length - 1) return;
            EntityPowerType type = characterInPositon.GetChracterAllPowerType()[index];
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
}
