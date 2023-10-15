using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject loadingPanel;
    [SerializeField] private float waitingTime;

    private void Start()
    {
        StartCoroutine(LoadingGameScene());
    }

    private IEnumerator LoadingGameScene()
    {
        yield return new WaitForSeconds(waitingTime);
        loadingPanel.SetActive(false);
    }
}
