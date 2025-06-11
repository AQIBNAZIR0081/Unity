using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100; // Maximum health value
    [SerializeField] private Slider healthSlider; // Reference to the Slider component
    [SerializeField] private AudioClip carDamageSoundClip; // Sound to play on damage
    [SerializeField] private GameObject GameOverPanel; // Reference to the Game Over panel

    private int currentHealth;
    AudioSource carDamageSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(GameOverPanel != null && GameOverPanel.activeInHierarchy)
        {
            GameOverPanel.SetActive(false); // Ensure Game Over panel is hidden at start
        }
        carDamageSound = GetComponent<AudioSource>();

        // If healthSlider is not assigned in the Inspector, try to find it in the children
        if (healthSlider == null)
        {
            healthSlider = GetComponentInChildren<Slider>();
            if (healthSlider == null)
            {
                Debug.LogError("Health Slider not found in children of " + gameObject.name);
            }
        }

        // Initialize current health and slider
        currentHealth = maxHealth;
        UpdateHealthSlider();
    }

    // Update the health slider value
    private void UpdateHealthSlider()
    {
        if (healthSlider != null)
        {
            healthSlider.value = (float)currentHealth / maxHealth; // Normalize health to 0-1 for the Slider
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacles")) // Corrected tag name
        {
            carDamageSound.PlayOneShot(carDamageSoundClip); // Play damage sound
            TakeDamage(5); // Take 5 damage on collision
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth = Mathf.Max(0, currentHealth - damage); // Ensure health doesn't go below 0
        UpdateHealthSlider(); // Update slider when health changes

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Time.timeScale = 0;
        GameOverPanel.SetActive(true); // Show Game Over panel
        Destroy(gameObject); // Destroy the car when health reaches zero
    }

}
