using UnityEngine;
using UnityEngine.UI;

public class BattleGroundController : MonoBehaviour
{
    [SerializeField] private Character characterPrefab;
    [SerializeField] private BattleGroundView view;

    [SerializeField] private GameObject[] characterPositions = new GameObject[4];

    private GameObject mob;

    public void ChouiseCharacter(CharacterModel model) => characterPrefab.SetCharacterModel(model);

    public void CoisePosition(int index)
    {
        if (characterPositions[index] != null && CheckDoubleCharacters())
        {
            Destroy(characterPositions[index].gameObject);
            view.SetCharacterImage(characterPrefab.GetCharacterSprite(), index);
            characterPositions[index] = Instantiate(characterPrefab.gameObject, this.transform, true);
            characterPositions[index].GetComponent<Character>().SetMob(mob);
        }
        else if (characterPositions[index] == null && CheckDoubleCharacters())
        {
            view.SetCharacterImage(characterPrefab.GetCharacterSprite(), index);
            characterPositions[index] = Instantiate(characterPrefab.gameObject, this.transform, true);
            characterPositions[index].GetComponent<Character>().SetMob(mob);
        }
    }

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

    private bool CheckDoubleCharacters()
    {
        foreach(GameObject character in characterPositions)
        {
            if (character == null) continue;
            else if (character.GetComponent<Character>().GetCharacterIndex() == characterPrefab.GetCharacterIndex())
            {
                return false;
            }
        }
        return true;
    }
}
