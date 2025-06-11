using UnityEngine;

public class DriverScript : MonoBehaviour
{
    
    [SerializeField] float steerSpeed = 100.0f;
    [SerializeField] float moveSpeed = 15.0f;

    // Update is called once per frame
    void Update()
    {
        CarMovement();
    }

    private void CarMovement()
    {
        // Get the horizontal and vertical input axes
        float horizontalMovement = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float verticalMovement = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -horizontalMovement);
        transform.Translate(0, verticalMovement, 0);
    }
}
