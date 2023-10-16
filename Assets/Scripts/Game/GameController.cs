using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private ClickerController playerClick;

    [SerializeField] public GameObject mob;
    private void Update()
    {
        playerClick.damageMob = mob;
    }
}
