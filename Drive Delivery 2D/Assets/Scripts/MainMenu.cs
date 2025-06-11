using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void OnClickPlayButton()
    {
        // Load the game scene (assuming it's named "GameScene")
        SceneManager.LoadScene("Level1");
    }

    public void OnClickQuitButton()
    {
        // Quit the application
        Application.Quit();
    }
}
