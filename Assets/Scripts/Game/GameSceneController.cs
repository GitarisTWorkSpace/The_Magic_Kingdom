using System.Collections;
using UnityEngine;

public class GameSceneController : MonoBehaviour
{
    [SerializeField] private GameObject loadingPanel;
    [SerializeField] private AdviceView adviceView;
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
