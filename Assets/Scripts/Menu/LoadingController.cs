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

    public void ActivateLoadingPanel()
    {
        gameObject.SetActive(true);
        adviceView.SetAdviceText();
        StartCoroutine(TestloadingPanel());
    }

    private IEnumerator TestloadingPanel()
    {
        loadingAnimator.SetTrigger("SceneStart");
        yield return new WaitForSeconds(1.5f);
        loadingAnimator.SetBool("SceneStart", false);
        gameObject.SetActive(true);
        yield return new WaitForSeconds(waitingTime*2);
        loadingAnimator.SetTrigger("SceneEnd");
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
