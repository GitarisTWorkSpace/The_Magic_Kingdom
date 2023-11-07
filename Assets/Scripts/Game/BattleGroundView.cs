using UnityEngine;
using UnityEngine.UI;

public class BattleGroundView : MonoBehaviour
{
    [SerializeField] private GameObject[] numberPositionImages;
    [SerializeField] private GameObject[] buyPositionButton;
    [SerializeField] private bool[] isBuyPostion = new bool[4];
    [SerializeField] private GameObject[] destroyCharacterButton;

    [SerializeField] private GameObject[] imageCharacterObj;
    [SerializeField] private Image[] imageCharacters;

    private bool isOpen = false;

    public void HiddenPlayGround(bool status)
    {
        isOpen = status;
        SetActivePanels(status, numberPositionImages);
        SetBuyButton(status);
        SetActiveDestroyCharacterButton(status);
    }

    public void SetCharacterImage(Sprite characterSprite, int positionIndex, bool status)
    {
        imageCharacterObj[positionIndex].SetActive(status);
        imageCharacters[positionIndex].sprite = characterSprite;
        if (isOpen) SetActiveDestroyCharacterButtonByIndex(positionIndex, status);
    }

    public void SetBuyPosition(int positionIndex)
    {
        buyPositionButton[positionIndex].SetActive(false);
        isBuyPostion[positionIndex] = true;
    }

    private void SetActiveDestroyCharacterButtonByIndex(int positionIndeex, bool status)
    {
        destroyCharacterButton[positionIndeex].SetActive(status);
    }

    private void Start()
    {
        LoadBuyPosition();
    }

    private void OnEnable()
    {
        Character.characterAtacked += CharacterAtack;
    }

    private void OnDisable()
    {
        Character.characterAtacked -= CharacterAtack;
    }

    private void CharacterAtack(int positionIndex)
    {
        imageCharacterObj[positionIndex].GetComponent<Animation>().Play();
    }

    private void SetActivePanels(bool state, GameObject[] panels)
    {
        foreach (GameObject item in panels)
        {
            item.SetActive(state);
        }
    }

    private void SetActiveDestroyCharacterButton(bool status)
    {        
        for (int i = 0; i < destroyCharacterButton.Length; i++)
        {
            destroyCharacterButton[i].SetActive(status);
            if (!imageCharacterObj[i].activeInHierarchy) destroyCharacterButton[i].SetActive(false);
        }
    }    

    private void SetBuyButton(bool status)
    {
        for (int i = 0; i < buyPositionButton.Length; i++)
        {
            buyPositionButton[i].SetActive(status);
            if (isBuyPostion[i]) buyPositionButton[i].SetActive(false);
        }
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
}
