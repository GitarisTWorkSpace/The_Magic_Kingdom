using System.Collections;
using TMPro;
using UnityEngine;

public class InfoText : MonoBehaviour
{
    [SerializeField] private TMP_Text infoGameText;
    [SerializeField] private float cleareTime;

    private void Start()
    {
        StartCoroutine(CleareText());
    }

    private IEnumerator CleareText()
    {
        yield return new WaitForSeconds(cleareTime);
        infoGameText.text = "";
    }
}
