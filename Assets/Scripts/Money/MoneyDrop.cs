using UnityEngine;

public class MoneyDrop : MonoBehaviour
{
    [SerializeField] private CristalController cristal;
    [SerializeField] private CoinController coin;
    [SerializeField] private Sprite coinSprite;
    [SerializeField] private Sprite cristalSprite;

    public void DropCoin()
    {
        int rnd = Random.Range(15, 1000);
        //int amont = 0;
        //if (rnd >= 100) amont = rnd / 50;
        //if (rnd < 100) amont = rnd / 10;
        coin.AddCoin(rnd);
    }

    public void DropCristal(int chanse)
    {        
        int chanseRnd = Random.Range(1, 100);
        if(chanseRnd <= chanse)
        {
            int amountRnd = Random.Range(1, 4);
            cristal.AddCristals(amountRnd);
        }
    }
}
