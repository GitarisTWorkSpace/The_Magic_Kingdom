using System.Collections;
using UnityEngine;

public class MoneyTransportation : MonoBehaviour
{
    [SerializeField] private float destroyTime;
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "Coin" || collision.tag == "Cristal")
        {
            collision.GetComponent<Rigidbody>().isKinematic = true;
            collision.GetComponent<Animation>().Play();
            Destroy(collision.gameObject, destroyTime);
        }
    }
}
