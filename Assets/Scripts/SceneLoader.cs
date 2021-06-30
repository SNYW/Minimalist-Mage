using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    GameObject fadeOutPanel;

    public void LoadRun()
    {
        SceneManager.LoadScene(1);
    }

    public void FadeOut()
    {
        fadeOutPanel.GetComponent<Animator>().Play("MainMenuFadeout");
    }
}
