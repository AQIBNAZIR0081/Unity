using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class CashSystem : MonoBehaviour
    {
        [SerializeField] private int cashAmount = 0; // Initial cash amount
        [SerializeField] private Text cashText; // UI Text component to display cash

        private const string CASH_KEY = "Cash"; // Key for PlayerPrefs
        // Use this for initialization
        void Start()
        {
            // Load the cash amount from PlayerPrefs if it exists, otherwise use the initial value
            if (PlayerPrefs.HasKey(CASH_KEY))
            {
                cashAmount = PlayerPrefs.GetInt(CASH_KEY, 0);
            }
            UpdateUI(); // Initialize the UI with the starting cash amount
        }

        public void AddCash()
        {
            cashAmount += Random.Range(100, 201); // Randomly add cash between 1 and 10
            PlayerPrefs.SetInt(CASH_KEY, cashAmount); // Save the updated cash amount to PlayerPrefs
            PlayerPrefs.Save(); // Ensure the PlayerPrefs are saved
            UpdateUI(); // Update the UI to reflect the new cash amount
        }

        public void UpdateUI()
        {
            cashText.text = "Cash: $" + cashAmount.ToString();
        }

        public void ResetCash()
        {
            cashAmount = 0;
            PlayerPrefs.SetInt(CASH_KEY, cashAmount);
            PlayerPrefs.Save();
            UpdateUI();
        }
    }
}