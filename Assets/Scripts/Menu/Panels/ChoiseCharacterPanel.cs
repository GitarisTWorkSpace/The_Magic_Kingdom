using UnityEngine;

public class ChoiseCharacterPanel : MonoBehaviour
{
    [SerializeField] private GameObject choiseCharacretPanel;
    private bool isOpen = false;

    public void OpenClosePanel()
    {
        if (isOpen)
        {
            choiseCharacretPanel.SetActive(false);
            isOpen = false;
        }
        else if (!isOpen)
        {
            choiseCharacretPanel.SetActive(true);
            isOpen = true;
        }
    }

    public void ClosePanel()
    {
        choiseCharacretPanel.SetActive(false);
        isOpen = false;
    }
}
