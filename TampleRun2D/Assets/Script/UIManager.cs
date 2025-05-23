using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject resumePanel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        resumePanel.SetActive(false);    
    }

    public void OnClickPauseButton()
    {
        resumePanel.SetActive(true);
        Time.timeScale = 0; // Pause the game
    }

    public void OnClickResumeButton()
    {
        resumePanel.SetActive(false);
        Time.timeScale = 1; // Resume the game
    }
}
