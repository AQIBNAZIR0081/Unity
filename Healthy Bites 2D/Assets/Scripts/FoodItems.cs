using UnityEngine;

public class FoodItems : MonoBehaviour
{
    public float fallSpeed = 2f;
    private float destroyY = -5f;

    void Update()
    {
        // Move downward
        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);

        // Destroy if below screen
        if (transform.position.y < destroyY)
        {
            Destroy(gameObject);
        }
    }

    void OnMouseDown()
    {
        GameManager.Instance.FoodClicked(gameObject.tag);
        Destroy(gameObject);
    }
}
