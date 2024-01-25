using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame() {
        SceneManager.LoadScene("PlayGame");
    }

    public void Settings() {
        Debug.Log("Settings()");
    }

    public void Quit() {
        Application.Quit();
    }
}
