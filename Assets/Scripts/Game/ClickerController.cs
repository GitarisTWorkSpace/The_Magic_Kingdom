using UnityEngine;

public class ClickerController : MonoBehaviour
{
    [SerializeField] public GameObject damageMob;
    [SerializeField] private float damageToMob;

    public void DamageToMob()
    {
        Debug.Log("������� ����");
        damageMob.GetComponent<IDamageble>().TakeDemage(damageToMob);
    }
}
