using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingController : MonoBehaviour
{
    [SerializeField] private Animator loadingAnimator;
    [SerializeField] private Slider loadingBar;
    [SerializeField] private enum TypeLoading 
    {
        Scene,
        Location
    }
    [SerializeField] private TypeLoading typeLoading;

    private AsyncOperation loadingSceneOperation;

    private void Start()
    {
        loadingBar.maxValue = 100f;
        loadingAnimator = GetComponent<Animator>();
    }

    public void StartGame()
    {
        gameObject.SetActive(true);
        if (typeLoading == TypeLoading.Scene)
            LoadNewScene();
        else if (typeLoading == TypeLoading.Location)
            LoadNewLocation();
    }    

    public void OnAnimationOver()
    {
        if (typeLoading == TypeLoading.Scene)
            loadingSceneOperation.allowSceneActivation = true;
        else if (typeLoading == TypeLoading.Location)
            loadingAnimator.Play("OffLoading");
    }

    public void HiddenPanel() => gameObject.SetActive(false);

    private void LoadNewScene()
    {
        loadingAnimator.Play("OnLoading");
        loadingSceneOperation =  SceneManager.LoadSceneAsync("Game");
        loadingSceneOperation.allowSceneActivation = false;
        typeLoading = TypeLoading.Scene;
    }

    private void LoadNewLocation() 
    {
        loadingAnimator.Play("OnLoading");
        typeLoading = TypeLoading.Location;
    }
}
