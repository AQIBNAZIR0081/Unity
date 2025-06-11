using UnityEngine;

public class DriverScript : MonoBehaviour
{
    // Singleton instance of DriverScript
    public static DriverScript Instance { get; private set; }

    [SerializeField] float steerSpeed = 100.0f;
    [SerializeField] float moveSpeed = 15.0f;
    
    bool isMoving;

    private void Awake()
    {
        // Ensure only one instance of DriverScript exists
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }


    // Update is called once per frame
    void Update()
    {
        CarMovement();
    }

    private void CarMovement()
    {
        isMoving = true;
        // Get the horizontal and vertical input axes
        float horizontalMovement = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float verticalMovement = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -horizontalMovement);
        transform.Translate(0, verticalMovement, 0);
    }
}
