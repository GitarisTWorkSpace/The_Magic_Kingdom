using System;
using TMPro;
using UnityEngine;

public class SpawnerMobsController : MonoBehaviour
{
    [Header("Ojects")]
    [SerializeField] private MoneyDrop drop;
    [SerializeField] private Mob mobPrefab;
    [SerializeField] private MobModel[] mobList;
    [SerializeField] private MobModel[] bossList;

    [SerializeField] private int mobCount;

    [SerializeField] private TMP_Text mobCountText;

    private Mob mob;

    public static Action<GameObject> instantiatedMob;

    public void CleareMobCount()
    {
        mobCount = 0;
        SaveMobCount();
    }

    private void Start()
    {
        LoadMobCount();
        SpawnMobs();        
    }

    private void SpawnMobs()
    {
        if (CheckMobCount())
        {
            instantiatedMob?.Invoke(mob.gameObject);
            SaveMobCount();
            mobCount++;
            return;
        }
        SaveMobCount();
        mobCount++;
        mobCountText.text = mobCount.ToString();    
        int index = UnityEngine.Random.Range(0, mobList.Length);
        mobPrefab.drop = drop;
        mobPrefab.mobModel = mobList[index];
        mob = Instantiate(mobPrefab, this.transform, true);
        instantiatedMob?.Invoke(mob.gameObject);
    }

    private void SpawnNeededMob(MobModel mobModel)
    {
        mobPrefab.drop = drop;
        mobPrefab.mobModel = mobModel;
        mob = Instantiate(mobPrefab, this.transform, true);
        instantiatedMob?.Invoke(mob.gameObject);
    }

    private bool CheckMobCount()
    {
        if(mobCount == 50) 
        {
            SpawnNeededMob(bossList[0]);
            return true;
        }
        else if (mobCount == 250)
        {
            SpawnNeededMob(bossList[1]);
            return true;
        }
        return false;
    }

    private void Update()
    {
        if (gameObject.transform.childCount == 0)
        {
            SpawnMobs();
        }
    }

    private void SaveMobCount()
    {
        PlayerPrefs.SetInt("MobCount", mobCount);
    }

    private void LoadMobCount()
    {
        if (PlayerPrefs.HasKey("MobCount"))
            mobCount = PlayerPrefs.GetInt("MobCount");
    }
}
