using UnityEngine;

public class ObjectInstanciate : MonoBehaviour
{
    public GameObject apple;
    public GameObject coin;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i <= 10; i++)
        {
            Vector2 applepos = new Vector2(Random.Range(-3, 80), Random.Range(1, 4));
            Instantiate(apple, applepos, Quaternion.identity);

            Vector2 coinpos = new Vector2(Random.Range(-4, 70), Random.Range(0, 5));
            Instantiate(coin, coinpos, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}