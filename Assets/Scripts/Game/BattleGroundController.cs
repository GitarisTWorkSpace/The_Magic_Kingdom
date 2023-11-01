using System.Collections;
using UnityEngine;

public class BattleGroundController : MonoBehaviour
{
    [SerializeField] private Character characterPrefab;
    [SerializeField] private BattleGroundView view;

    [SerializeField] private float cleareTime;

    [SerializeField] private GameObject[] characterPositions = new GameObject[4];

    [SerializeField] private Character instanseCharacter;
    private GameObject mob;

    public void ChouiseCharacter(CharacterModel model)
    {
        instanseCharacter = characterPrefab;
        instanseCharacter.SetCharacterModel(model);
        view.SetActiveNumberImages(true);
        StartCoroutine(CleareChoiseCharacter());
    }

    public void DescroyCharacter(int positionIndex)
    {
        view.SetCharacterImage(null, positionIndex, false);
        Destroy(characterPositions[positionIndex].gameObject);
        characterPositions[positionIndex] = null;
    }

    public void CoisePosition(int positionIndex)
    {
        if (characterPositions[positionIndex] != null)
        {
            CheckCopyCharacters(positionIndex);
            DescroyCharacter(positionIndex);
            SpawnCharacter(positionIndex);
        }
        else if (characterPositions[positionIndex] == null) 
        {
            CheckCopyCharacters(positionIndex);
            SpawnCharacter(positionIndex);
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

    private void SpawnCharacter(int positionIndex)
    {
        view.SetCharacterImage(instanseCharacter.GetCharacterSprite(), positionIndex, true);

        characterPositions[positionIndex] = Instantiate(instanseCharacter.gameObject, this.transform, true);

        characterPositions[positionIndex].GetComponent<Character>().SetMob(mob);
        characterPositions[positionIndex].GetComponent<Character>().SetPositionIndex(positionIndex);
    }

    private void CheckCopyCharacters(int positionIndex)
    {
        foreach (GameObject character in characterPositions)
        {
            if (character == null) continue;
            else if (character.GetComponent<Character>().GetCharacterIndex() == instanseCharacter.GetCharacterIndex())
            {
                DescroyCharacter(character.GetComponent<Character>().GetPositionIndex());
            }
        }
    }

    private IEnumerator CleareChoiseCharacter()
    {
        yield return new WaitForSeconds(cleareTime);
        instanseCharacter = null;
    }
}
