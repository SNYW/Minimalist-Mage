using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    GameObject fadeOutPanel;

    public void LoadRun()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
    public void LoadMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void FadeOut()
    {
        Time.timeScale = 1;
        fadeOutPanel.GetComponent<Animator>().Play("MainMenuFadeout");
    }
}
