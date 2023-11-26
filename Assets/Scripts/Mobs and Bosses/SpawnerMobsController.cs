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

    [SerializeField] private Mob mob;

    [SerializeField] private bool spawnNeedMob;
    [SerializeField] private MobModel neededMob;
    [SerializeField] private int neededMobCount;

    public static Action<GameObject> instantiatedMob;

    public void CleareMobCount()
    {
        mobCount = 0;
        SaveMobCount();
    }

    public GameObject GetCurrenMob() => mob.gameObject;

    public void SetNeededMob(MobModel mob, int count)
    {
        neededMob = mob;
        neededMobCount = mobCount + count;
        spawnNeedMob = true;
    }

    private void Start()
    {
        LoadMobCount();

        CheckMobCount();
        if (!spawnNeedMob)
        {
            MainSpawner();
        }
        else if (spawnNeedMob)
        {
            SpawnNeededMob();
        }
    }

    private void MainSpawner()
    {
        MobDeadCounter();
        int index = UnityEngine.Random.Range(0, mobList.Length);
        SpawnMob(mobList[index]);
    }

    private void SpawnMob(MobModel mobModel)
    {
        mobPrefab.drop = drop;
        mobPrefab.mobModel = mobModel;
        mob = Instantiate(mobPrefab, this.transform, true);
        instantiatedMob?.Invoke(mob.gameObject);
    }

    private void SpawnNeededMob()
    {
        if (neededMobCount <= mobCount) spawnNeedMob = false;
        else
        {
            MobDeadCounter();
            SpawnMob(neededMob);
        }
    }

    private void MobDeadCounter()
    {
        SaveMobCount();
        mobCount++;
        if (mobCountText != null)
            mobCountText.text = mobCount.ToString();
    }

    private void CheckMobCount()
    {
        if(mobCount == 150) 
        {
            neededMob = bossList[0];
            neededMobCount = mobCount + 1;
            spawnNeedMob = true;
        }
        else if (mobCount == 480)
        {
            neededMob = bossList[1];
            neededMobCount = mobCount + 1;
            spawnNeedMob = true;
        }
    }

    private void Update()
    {
        if (gameObject.transform.childCount == 0)
        {
            CheckMobCount();
            if (!spawnNeedMob)
            {
                MainSpawner();
            }
            else if(spawnNeedMob)
            {
                SpawnNeededMob();
            }
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
