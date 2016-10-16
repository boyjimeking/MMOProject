using UnityEngine;

public class CameraManager : MonoBehaviour
{
    Transform TrackTarget { get; set; }

    void Update()
    {
        if (TrackTarget != null)
        {
            transform.position = TrackTarget.position;
        }
    }

    public void SetTrackTarget(Transform target)
    {
        TrackTarget = target;
    }
}
