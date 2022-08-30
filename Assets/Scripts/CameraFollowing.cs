using UnityEngine;

public class CameraFollowing : MonoBehaviour
{
    [SerializeField] private Transform _ballTransform;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _smoothSpeed;

    private void FixedUpdate()
    {
        Vector3 desiredPosition = _ballTransform.position + _offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, _smoothSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(_ballTransform.position);
    }
}
