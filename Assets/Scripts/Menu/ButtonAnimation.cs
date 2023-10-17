using UnityEngine;
using UnityEngine.UIElements;

public class ButtonAnimation : MonoBehaviour
{
    [SerializeField] public Animation animationButton;

    [SerializeField] private AnimationClip[] animationClips;

    [SerializeField] private bool status = false;

    private void Start()
    {
        animationButton = GetComponent<Animation>();
    }

    public void OpenClosePanel()
    {
        if (!status)
        {
            animationButton.clip = animationClips[0];
            animationButton.Play();
            status = true;
        }
        else if (status)
        {
            animationButton.clip = animationClips[1];
            animationButton.Play();
            status = false;
        }
    }
}
