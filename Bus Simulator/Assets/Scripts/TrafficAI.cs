using UnityEngine;

public class TrafficAI : MonoBehaviour
{
    
    float speed = 5f;
    Vector3 initialPosition;
    private void Start()
    {
        // Store the initial position of the car
        initialPosition = transform.position; 
    }

    void Update()
    {
        Vector3 CurrentPosition = transform.position;
        // Move the car in the forward direction
        transform.Translate(0,0, speed * Time.deltaTime);

        // If the car reaches the end of the road, reset the position of the car
        if (CurrentPosition.z >= 400)
        {
            transform.position = initialPosition;
        }

    }

}
