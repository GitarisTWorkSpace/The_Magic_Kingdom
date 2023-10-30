using UnityEngine;

public class MoneyDestroy : MonoBehaviour
{
    [SerializeField] private float destroyTime;
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "Coin" || collision.tag == "Cristal")
        {
            collision.GetComponent<Rigidbody>().isKinematic = true;
            Destroy(collision.gameObject, destroyTime);
        }
    }
}
