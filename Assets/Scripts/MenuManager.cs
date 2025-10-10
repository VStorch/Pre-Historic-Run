using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject startScreen;
    public GameObject aboutScreen;
    public string level;

    public void Play()
    {
        SceneManager.LoadScene(level);
    }
    public void OpenAboutScreen()
    {
        startScreen.SetActive(false);
        aboutScreen.SetActive(true);
    }

    public void CloseAboutScreen()
    {
        startScreen.SetActive(true);
        aboutScreen.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
