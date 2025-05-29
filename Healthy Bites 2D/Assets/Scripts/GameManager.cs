using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int health = 30;
    public Text healthText;
    public GameObject gameOverText;
    public GameObject winText;
    public string mainSceneName = "SampleScene"; // Name of the main scene to reload

    private int currentHealth;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start()
    {
        currentHealth = health;
        UpdateUI();

        gameOverText.SetActive(false);
        winText.SetActive(false);
    }

    public void FoodClicked(string tag)
    {
        if(tag == "HealthyFood")
        {
            currentHealth += 5; // Increase health by 5 for healthy food
        }
        else if (tag == "JunkFood")
        {
            currentHealth -= 5; // Decrease health by 5 for unhealthy food
        }
        UpdateUI();
        CheckGameState();
    }

    private void UpdateUI()
    {
        healthText.text = "Health: " + currentHealth.ToString();
    }

    private void CheckGameState()
    {
        if (currentHealth >= 60)
        {
            winText.SetActive(true);
            PauseGame();
        }
        else if (currentHealth <= 0)
        {
            gameOverText.SetActive(true);
            Invoke("ReloadGame", 2f); // wait before reload
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0f;
    }

    void ReloadGame()
    {
        SceneManager.LoadScene(mainSceneName);
    }
}
