
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SinTransitionScript : MonoBehaviour
{
    public TextMeshProUGUI LoadingPercentage;
    public Image LoadingProgressBar;
    
    private static SinTransitionScript instance;
    private static bool shouldPlayOpeningAnimation = false; 
    
    private Animator componentAnimator;
    private AsyncOperation loadingSceneOperation;

    public static void SelectToScreen(int Scene)
    {
        instance.componentAnimator.SetTrigger("SceneEnd");

        instance.loadingSceneOperation = SceneManager.LoadSceneAsync(Scene);
        
        // Чтобы сцена не начала переключаться пока играет анимация closing:
        instance.loadingSceneOperation.allowSceneActivation = false;
        
        instance.LoadingProgressBar.fillAmount = 0;
    }
    
    private void Start()
    {
        instance = this;
        
        componentAnimator = GetComponent<Animator>();
        
        //if (shouldPlayOpeningAnimation) 
        //{
        //    componentAnimator.SetTrigger("SceneStart");
        //    instance.LoadingProgressBar.fillAmount = 1;
        //    
        //    // Чтобы если следующий переход будет обычным SceneManager.LoadScene, не проигрывать анимацию opening:
        //    shouldPlayOpeningAnimation = false; 
        //}
    }

    private void Update()
    {
        if (loadingSceneOperation != null)
        {
            LoadingPercentage.text = Mathf.RoundToInt(loadingSceneOperation.progress * 100) + "%";
            
            // Просто присвоить прогресс:
            LoadingProgressBar.fillAmount = loadingSceneOperation.progress; 
            
            // Присвоить прогресс с быстрой анимацией, чтобы ощущалось плавнее:
            LoadingProgressBar.fillAmount = Mathf.Lerp(LoadingProgressBar.fillAmount, loadingSceneOperation.progress, Time.deltaTime * 5);
        }
    }

    public void OnAnimationOver()
    {
        // Чтобы при открытии сцены, куда мы переключаемся, проигралась анимация opening:
        //shouldPlayOpeningAnimation = true;
        
        loadingSceneOperation.allowSceneActivation = true;

    }
}
