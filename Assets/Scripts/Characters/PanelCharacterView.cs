using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PanelCharacterView : MonoBehaviour
{
    [SerializeField] private CharacterModel characterModel;

    [SerializeField] private Image characterImage;

    [SerializeField] private TMP_Text characterName;
    [SerializeField] private TMP_Text characterLvl;

    private void Start()
    {
        characterImage.sprite = characterModel.GetCharacterSprite();
        characterName.text = characterModel.GetCharacterName();
        characterLvl.text = characterModel.GetCharacterLevel().ToString();
    }

    private void OnEnable()
    {
        CharacterModel.characterUpgraded += UpdateInfo;
    }

    private void OnDisable()
    {
        CharacterModel.characterUpgraded -= UpdateInfo;
    }

    private void UpdateInfo()
    {
        characterName.text = characterModel.GetCharacterName();
        characterLvl.text = characterModel.GetCharacterLevel().ToString();
    }
}