using UnityEngine;
using UnityEngine.Rendering;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject TrackingTarget; // The target to follow

    private void Start()
    {
        SetTarget(DriverScript.driveInstance.gameObject); // Set the tracking target to the driver instance
    }

    void LateUpdate()
    {
        if(TrackingTarget != null)
        {
            transform.position = TrackingTarget.transform.position + new Vector3(0, 0, -10);
        }
        else
        {
            return;
        }
    }

    private void SetTarget(GameObject gameObject)
    {
        TrackingTarget = gameObject; // Set the tracking target to the specified game object
    }

}
