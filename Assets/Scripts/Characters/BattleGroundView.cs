using UnityEngine;
using UnityEngine.UI;

public class BattleGroundView : MonoBehaviour
{
    [SerializeField] private GameObject[] numberPositionImages;
    [SerializeField] private GameObject[] imageCharacterObj;
    [SerializeField] private Image[] imageCharacters;

    public void SetActiveNumberImages(bool state)
    {
        foreach(GameObject numberImage in numberPositionImages)
        {
            numberImage.SetActive(state);
        }
    }

    public void SetCharacterImage(Sprite characterSprite, int index)
    {
        imageCharacterObj[index].SetActive(true);
        imageCharacters[index].sprite = characterSprite;
        SetActiveNumberImages(false);
    }
}
