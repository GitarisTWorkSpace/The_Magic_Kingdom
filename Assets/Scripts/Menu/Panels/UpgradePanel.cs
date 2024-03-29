using UnityEngine;

public class UpgradePanel : MonoBehaviour
{
    [SerializeField] private Animation animPanel;
    [SerializeField] private AnimationClip[] animPanelClips;
    private bool isOpen = false;
    void Start()
    {
        animPanel = GetComponent<Animation>();
    }

    public void OpenClosePanel()
    {
        if (isOpen)
        {
            animPanel.Play();
            animPanel.clip = animPanelClips[0];
            isOpen = false;
        }
        else if (!isOpen)
        {
            animPanel.Play();
            animPanel.clip = animPanelClips[1];
            isOpen = true;
        }
    }

    public void CloseUpgradePanel()
    {
        if (isOpen) 
        {
            animPanel.clip = animPanelClips[1];
            animPanel.Play();
            animPanel.clip = animPanelClips[0];
            isOpen = false;
        }        
    }
}
