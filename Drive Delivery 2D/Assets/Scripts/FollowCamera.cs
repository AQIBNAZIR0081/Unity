using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject TrackingTarget; // The target to follow

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = TrackingTarget.transform.position + new Vector3(0, 0, -10);
    }
}
