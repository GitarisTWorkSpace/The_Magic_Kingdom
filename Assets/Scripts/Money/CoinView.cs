using TMPro;
using UnityEngine;

public class CoinView : MonoBehaviour
{
    [SerializeField] private CoinModel coinModel;
    [SerializeField] private TMP_Text coinText;

    private void Update()
    {
        coinText.text = coinModel.GetCoinCount().ToString();
    }

}
