using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField]
    Transform _trackTarget;

    void Update()
    {
        if (_trackTarget != null)
        {
            transform.position = _trackTarget.position;
        }
    }
}
