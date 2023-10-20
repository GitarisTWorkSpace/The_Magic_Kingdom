using UnityEngine;

public class MoneyTransportation : MonoBehaviour
{
    [SerializeField] private GameObject coinEndPoint;
    [SerializeField] private GameObject cristalEndPoint;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Coin")
        {
            collision.transform.position = coinEndPoint.transform.position;
        }
        else if (collision.tag == "Cristal")
        {
            collision.transform.position = coinEndPoint.transform.position;
        }
    }
}
