using System.Collections;
using UnityEngine;

public class InstantiateFood : MonoBehaviour
{
    public GameObject[] foodPrefeb;

    private int foodIndex;
    private Coroutine coroutine;

    void Start()
    {
        StartInstantiating();
    }

    //Starting Coroutine to instantiate food items
    public void StartInstantiating()
    {
        coroutine = StartCoroutine(InstantiateFoodCoroutine());
    }

    //Stopping Coroutine to instantiate food items
    public void StopInstantiating()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
            coroutine = null;
        }
    }

    //Coroutine to instantiate food items at random positions
    private IEnumerator InstantiateFoodCoroutine()
    {
        while (true)
        {
            // Generate a random position within the specified range
            Vector2 instancePosition = new Vector2(Random.Range(-8f, 8f), Random.Range(8f, 8f));

            // Randomly select a food prefab from the array
            int randomIndex = Random.Range(0, foodPrefeb.Length);

            // Instantiate the selected food prefab at the generated position
            Instantiate(foodPrefeb[randomIndex], instancePosition,Quaternion.identity);
            yield return new WaitForSeconds(1f); // Adjust the delay
        }
    }
}
