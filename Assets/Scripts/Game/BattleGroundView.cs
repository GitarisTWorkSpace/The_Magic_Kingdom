using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BattleGroundView : MonoBehaviour
{
    [SerializeField] private float cleareTime;
    [SerializeField] private GameObject[] numberPositionImages;
    [SerializeField] private GameObject[] imageCharacterObj;
    [SerializeField] private Image[] imageCharacters;

    public void SetActiveNumberImages(bool state)
    {
        foreach(GameObject numberImage in numberPositionImages)
        {
            numberImage.SetActive(state);
        }

        if (state) StartCoroutine(HiddenNumberImages());
    }

    public void SetCharacterImage(Sprite characterSprite, int positionIndex, bool status)
    {
        imageCharacterObj[positionIndex].SetActive(status);
        imageCharacters[positionIndex].sprite = characterSprite;
        SetActiveNumberImages(false);
    }

    private IEnumerator HiddenNumberImages()
    {
        yield return new WaitForSeconds(cleareTime);
        SetActiveNumberImages(false);
    }
}
