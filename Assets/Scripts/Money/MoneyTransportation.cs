using System.Collections;
using UnityEngine;

public class MoneyTransportation : MonoBehaviour
{
    [SerializeField] private float destroyTime;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Coin" || collision.tag == "Cristal")
        {
            collision.GetComponent<Rigidbody2D>().simulated = false;
            collision.GetComponent<Animation>().Play();
            Destroy(collision.gameObject, destroyTime);
        }
    }
}
