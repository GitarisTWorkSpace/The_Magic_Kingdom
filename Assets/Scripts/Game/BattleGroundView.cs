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

    public void HiddenPlayGround(bool status)
    {
        SetActivePanels(status, numberPositionImages);
        SetBuyButton(status);
        SetActivePanels(status, destroyCharacterButton);
    }

    public void SetCharacterImage(Sprite characterSprite, int positionIndex, bool status)
    {
        imageCharacterObj[positionIndex].SetActive(status);
        imageCharacters[positionIndex].sprite = characterSprite;
    }

    public void SetBuyPosition(int positionIndex)
    {
        buyPositionButton[positionIndex].SetActive(false);
        isBuyPostion[positionIndex] = true;
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
    
    private void SetBuyButton(bool status)
    {
        for (int i = 0; i < buyPositionButton.Length; i++)
        {
            if (isBuyPostion[i]) buyPositionButton[i].SetActive(false);
            else buyPositionButton[i].SetActive(status);
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
