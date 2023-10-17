using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("Translate Mob to")]
    [SerializeField] private ClickerController playerClick;
    [SerializeField] private MobView mobView;

    [SerializeField] private GameObject mob;

    public void SetMob(GameObject mob)
    {
        this.mob = mob;
        TranslateMobTo();
    }

    private void TranslateMobTo()
    {
        playerClick.damageMob = mob;
        mobView.mob = mob;
        mobView.SetSpraitMob();
    }
}
