using UnityEngine;

public class InfoPanel : MonoBehaviour
{
    [SerializeField] private GameObject mobHealthPointText;
    private bool isOpen = false;

    public void HiddenInfo()
    {
        if (isOpen)
        {
            mobHealthPointText.SetActive(false);
            isOpen = false;
        }
        else if (!isOpen)
        {
            mobHealthPointText.SetActive(true);
            isOpen = true;
        }
    }
}