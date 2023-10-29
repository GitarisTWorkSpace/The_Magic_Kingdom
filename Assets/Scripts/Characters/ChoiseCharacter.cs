using TMPro;
using UnityEngine;

public class ChoiseCharacter : MonoBehaviour
{
    [SerializeField] private TMP_Text someText;

    public void WriteSomeText(string text)
    {
        someText.text = text;
    }
}
