using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyDropView : MonoBehaviour
{
    [SerializeField] private TMP_Text coinText;
    [SerializeField] private TMP_Text cristalText;

    private void OnEnable()
    {
        MoneyDrop.ñhangedCoinText += ChangeCoin;
        MoneyDrop.changedCristalText += ChangeCristal;
    }

    private void OnDisable()
    {
        MoneyDrop.ñhangedCoinText -= ChangeCoin;
        MoneyDrop.changedCristalText -= ChangeCristal;
    }

    private void ChangeCoin(int coinValue)
    {
        StartCoroutine(ChangeCoinText(coinValue));
    }

    private IEnumerator ChangeCoinText(int coinValue)
    {
        coinText.text = "+ " + coinValue.ToString();
        yield return new WaitForSeconds(3);
        coinText.text = "";
    }

    private void ChangeCristal(int cristalValue)
    {
        StartCoroutine(ChangeCristalText(cristalValue));
    }

    private IEnumerator ChangeCristalText(int cristalValue)
    {
        cristalText.text = "+ " + cristalValue.ToString();
        yield return new WaitForSeconds(3);
        cristalText.text = "";
    }
}
