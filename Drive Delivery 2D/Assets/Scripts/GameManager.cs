using Assets.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    CashSystem cashSystem; // Reference to the CashSystem script

    private void Start()
    {
        if(cashSystem == null)
        {
            cashSystem = FindAnyObjectByType<CashSystem>(); // Find the CashSystem in the scene if not assigned
        }
    }

    public void RestartGame()
    {
        // Reload the current scene to restart the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1; // Ensure time scale is reset to normal

        cashSystem?.ResetCash(); // Reset cash amount in CashSystem
    }
}
