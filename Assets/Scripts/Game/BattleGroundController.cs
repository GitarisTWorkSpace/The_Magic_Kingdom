using System.Collections;
using UnityEngine;

public class BattleGroundController : MonoBehaviour
{
    [SerializeField] private CristalModel cristalModel;
    [SerializeField] private CristalController cristalController;

    [SerializeField] private CharacterModel[] characterModels;
    [SerializeField] private Character characterPrefab;
    [SerializeField] private BattleGroundView view;

    [SerializeField] private float cleareTime;

    [SerializeField] private GameObject[] characterPositions = new GameObject[4];
    [SerializeField] private bool[] isBuyPostion = new bool[4];
    [SerializeField] private int[] cristalAmountBuyPosition = new int[4];

    [SerializeField] private Character instanseCharacter;
    private GameObject mob;

    public void ChouiseCharacter(CharacterModel model)
    {
        instanseCharacter = characterPrefab;
        instanseCharacter.SetCharacterModel(model);
        StartCoroutine(CleareChoiseCharacter()); 
    }

    public void DescroyCharacter(int positionIndex)
    {
        view.SetCharacterImage(null, positionIndex, false);
        Destroy(characterPositions[positionIndex].gameObject);
        characterPositions[positionIndex] = null;
        PlayerPrefs.DeleteKey("CharacterPosition" + positionIndex.ToString());
    }

    public void CoisePosition(int positionIndex)
    {
        if (!isBuyPostion[positionIndex]) return;
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

    public void BuyPosition(int positionIndex)
    {
        if (cristalModel.GetCristalCount() >= cristalAmountBuyPosition[positionIndex])
        {
            isBuyPostion[positionIndex] = true;
            view.SetBuyPosition(positionIndex);
            cristalController.SubstractCristals(cristalAmountBuyPosition[positionIndex]);
            SaveBuyPosition(positionIndex);
        }
    }

    public void CleareIsBuyPosition()
    {
        for (int i = 0; i < isBuyPostion.Length; i++) 
        {
            PlayerPrefs.SetInt("BuyPosirion" + i, System.Convert.ToInt32(false));
        }
    }

    private void Start()
    {
        LoadBuyPosition();
        LoadCharacterInPositon();
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

        SaveCharacterInPositon(positionIndex);
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

    private void SaveBuyPosition(int positionIndex)
    {
        PlayerPrefs.SetInt("BuyPosirion" + positionIndex.ToString(), System.Convert.ToInt32(isBuyPostion[positionIndex]));
    }

    private void LoadBuyPosition()
    {
        for (int i = 0; i < isBuyPostion.Length; i++)
        {
            if (PlayerPrefs.HasKey("BuyPosirion" + i))
            {
                isBuyPostion[i] = System.Convert.ToBoolean(PlayerPrefs.GetInt("BuyPosirion" + i));
            }
            else isBuyPostion[i] = false;
        }
    }

    private void SaveCharacterInPositon(int positionIndex)
    {
        PlayerPrefs.SetInt("CharacterPosition" + positionIndex.ToString(), instanseCharacter.GetCharacterIndex());
        Debug.Log("CharacterPosition" + positionIndex.ToString() + " \n"+ instanseCharacter.GetCharacterIndex());
    }

    private void LoadCharacterInPositon()
    {
        for (int i = 0; i < characterPositions.Length;i++) 
        { 
            if (PlayerPrefs.HasKey("CharacterPosition" + i))
            {
                ChouiseCharacter(characterModels[PlayerPrefs.GetInt("CharacterPosition" + i)]);
                CoisePosition(i);
                Debug.Log("CharacterPosition" + i + " \n" + characterModels[PlayerPrefs.GetInt("CharacterPosition" + i)]);
            }
        }
    }
}
