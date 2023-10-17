using UnityEngine;
using UnityEngine.UI;

public class MobView : MonoBehaviour
{
    [SerializeField] private Image mobSprite;
    [SerializeField] private Slider mobHealthBar;

    [SerializeField] public GameObject mob;

    public void SetSpraitMob()
    {
        mobSprite.sprite = mob.GetComponent<Mob>().GetSprite();
    }

    private void Update()
    {
        if(mob != null) mobHealthBar.value = mob.GetComponent<Mob>().GetHealth();
    }
}
