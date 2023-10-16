using UnityEngine;

public class ButtonAnimation : MonoBehaviour
{
    [SerializeField] private Animation animation;

    [SerializeField] private AnimationClip[] animationClips;

    [SerializeField] private bool status = false;

    private void Start()
    {
        animation = GetComponent<Animation>();
    }

    public void OpenClosePanel()
    {
        if (!status)
        {
            animation.clip = animationClips[0];
            animation.Play();
            status = true;
        }
        else if (status)
        {
            animation.clip = animationClips[1];
            animation.Play();
            status = false;
        }
    }
}
