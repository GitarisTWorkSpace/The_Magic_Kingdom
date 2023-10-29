using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingController : MonoBehaviour
{
    [SerializeField] private AdviceView adviceView;
    [SerializeField] private Slider loadingBar;
    [SerializeField] private Animator loadingAnimator;

    [SerializeField] private float waitingTime;

    private AsyncOperation loadingSceneOperation;

    private static bool shouldPlayOffAnimation = false;
        
    private void Start()
    {
        if (shouldPlayOffAnimation) StartCoroutine(EndLoadGameScane());
        adviceView.SetAdviceText();
    }

    public void StartGame()
    {
        gameObject.SetActive(true);
        loadingAnimator.SetTrigger("SceneStart");
        LoadGameScene();
    }    

    public void OnAnimationOver()
    {
        shouldPlayOffAnimation = true;
        loadingSceneOperation.allowSceneActivation = true;
    }

    public void OffAnimationOver()
    {
        gameObject.SetActive(false);
    }

    private void LoadGameScene()
    {        
        loadingSceneOperation = SceneManager.LoadSceneAsync("Game");
        loadingSceneOperation.allowSceneActivation = false;
    }

    private void Update()
    {
        if (loadingSceneOperation != null)
            loadingBar.value = loadingSceneOperation.progress;
    }

    private IEnumerator EndLoadGameScane()
    {
        yield return new WaitForSeconds(waitingTime);
        loadingAnimator.SetTrigger("SceneEnd");
    }
}
