using System.Collections;
using UnityEngine;

public class InstantiateFood : MonoBehaviour
{
    public GameObject[] foodPrefeb;

    private int foodIndex;
    private Coroutine coroutine;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartInstantiating();
    }

    // Update is called once per frame
    void Update()
    {
        
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
