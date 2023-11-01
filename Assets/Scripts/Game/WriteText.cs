using System.Collections;
using TMPro;
using UnityEngine;

public class WriteText : MonoBehaviour
{
    [SerializeField] private TMP_Text someText;
    [SerializeField] private float timeToCleare;

    private void Start()
    {
        StartCoroutine(CleareText());
    }

    public void WriteSomeText(string text)
    {
        someText.text = text;
        StartCoroutine(CleareText());
    }

    private IEnumerator CleareText()
    {
        yield return new WaitForSeconds(timeToCleare);
        someText.text = "";
    }
}