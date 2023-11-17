using UnityEngine;

public class InfoPanel : MonoBehaviour
{
    [SerializeField] private GameObject infoPanel;
    private bool isOpen = false;

    public void HiddenInfo()
    {
        if (isOpen)
        {
            infoPanel.SetActive(false);
            isOpen = false;
        }
        else if (!isOpen)
        {
            infoPanel.SetActive(true);
            isOpen = true;
        }
    }
}