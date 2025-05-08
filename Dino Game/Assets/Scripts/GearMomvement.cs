using UnityEngine;

public class GearMomvement : MonoBehaviour
{
    Vector2 position1;
    Vector2 position2;
    public Vector2 positionDifference = new Vector2(7f, 0f);

    void Start()
    {
        position1 = transform.position;
        position2 = position1 + positionDifference;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.Lerp(position1, position2, Mathf.PingPong(Time.time / 2f, 1f));
        transform.Rotate(0, 0, 90);
    }
}
