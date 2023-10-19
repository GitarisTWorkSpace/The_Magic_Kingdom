using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuController : MonoBehaviour
{
    [SerializeField] private Slider loadingBar;
    [SerializeField] private float waitingTime;
    [SerializeField] private GameObject loading;

    private void Start()
    {
        loadingBar.maxValue = 100f;
    }

    public void StartGame()
    {
        StartCoroutine(LoadingGaneScene());
    }

    private void MoveToGameScene()
    {
        SceneManager.LoadScene("Game");
    }

    public void StartAnimation()
    {
        loading.GetComponent<Animation>().Play();
    }

    private IEnumerator LoadingGaneScene()
    {
        while (loadingBar.value < 100)
        {
            loadingBar.value += Random.Range(0, 15);
            yield return new WaitForSeconds(waitingTime);
        }
        MoveToGameScene();
    }
}
