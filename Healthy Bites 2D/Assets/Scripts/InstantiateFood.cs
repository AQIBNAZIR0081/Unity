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

    public void StartInstantiating()
    {
        coroutine = StartCoroutine(InstantiateFoodCoroutine());
    }
    public void StopInstantiating()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
            coroutine = null;
        }
    }

    private IEnumerator InstantiateFoodCoroutine()
    {
        while (true)
        {
            Vector2 instancePosition = new Vector2(Random.Range(-8f, 8f), Random.Range(8f, 8f));
            int randomIndex = Random.Range(0, foodPrefeb.Length);
            Instantiate(foodPrefeb[randomIndex], instancePosition,Quaternion.identity);
            yield return new WaitForSeconds(1f); // Adjust the delay
        }
    }
}
