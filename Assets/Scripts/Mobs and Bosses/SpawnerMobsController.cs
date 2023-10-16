using UnityEngine;
using UnityEngine.UI;

public class SpawnerMobsController : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private Image mobSprite;
    [SerializeField] private Slider mobHealthBar;

    [Header("Ojects")]
    [SerializeField] private GameController gameController;
    [SerializeField] private Mob mobObject;
    [SerializeField] private MobModel[] mobList;
    private Mob mob;

    private void Start()
    {
        SpawnMobs();
    }

    private void SpawnMobs()
    {
        int index = Random.Range(0, mobList.Length);
        mobObject.mobModel = mobList[index];
        mobSprite.sprite = mobObject.GetSprite();
        mob = Instantiate(mobObject, this.transform, true);
        gameController.mob = mob.gameObject;
    }

    private void Update()
    {
        if(gameObject.transform.childCount == 0)
        {
            SpawnMobs();
        }
     
        mobHealthBar.value = mob.GetHealth();
    }
}
