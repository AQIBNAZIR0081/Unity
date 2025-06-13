using UnityEngine;

public class DriverScript : MonoBehaviour
{
    public static DriverScript driveInstance;

    [SerializeField] float steerSpeed = 100.0f;
    [SerializeField] float moveSpeed = 15.0f;

    private void Start()
    {
        if (driveInstance == null)
        {
            driveInstance = this; // Assign this instance to the static variable
            DontDestroyOnLoad(gameObject); // Prevent this instance from being destroyed when loading a new scene
        }
        else
        {
            Destroy(gameObject); // Ensure only one instance exists
        }
    }

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
