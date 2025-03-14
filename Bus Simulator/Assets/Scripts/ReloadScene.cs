using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour
{
    public void OnClickExitButton()
    {
        Application.Quit();
    }

    public void OnClickReloadButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnClickReplayButton()
    {
        SceneManager.LoadScene("MainScene");
    }
}
