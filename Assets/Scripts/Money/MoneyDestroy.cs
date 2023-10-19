using UnityEngine;

public class MoneyDestroy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Coin" || collision.tag == "Cristal")
        {
            Destroy(collision.gameObject);
        }
    }
}
