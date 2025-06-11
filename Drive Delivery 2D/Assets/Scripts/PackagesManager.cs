using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PackagesManager : MonoBehaviour
{
    [SerializeField] private Text packageCount;
    [SerializeField] private GameObject LevelCompletePanel;

    private int deliverPackages = 0; // Counter for delivered packages
    int totalPackages = 0; // Total number of packages in the scene
    
    private void Start()
    {
        LevelCompletePanel.SetActive(false); // Ensure the level complete panel is hidden at the start

        GameObject[] packages = GameObject.FindGameObjectsWithTag("Package"); // Find all game objects with the "Package" tag
        
        totalPackages = packages.Length; // Total number of packages in the scene
        
        UpdateUI();

    }

    public void UpdatePackageCount()
    {
        if(deliverPackages < totalPackages)
        {
            deliverPackages ++; // Increment the delivered packages count
        }
        if (deliverPackages == totalPackages) 
        {
            LevelCompletePanel.SetActive(true); // Show the level complete panel when all packages are delivered
        }
        UpdateUI();
    }

    private void UpdateUI()
    {
        packageCount.text = "Packages Delivered: " + deliverPackages + "/" + totalPackages; // Update the UI text with the new count
    }


    public void OnClickLoadNextLevel()
    {
        SceneManager.LoadScene("Level2"); // Load the next level when the button is clicked
    }
}
