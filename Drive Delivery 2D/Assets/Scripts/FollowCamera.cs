using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject TrackingTarget; // The target to follow


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
}
