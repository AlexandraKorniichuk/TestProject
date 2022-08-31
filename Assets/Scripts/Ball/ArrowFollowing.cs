using UnityEngine;

public class ArrowFollowing : MonoBehaviour
{
    [SerializeField] private Transform _ballTransform;
    [SerializeField] private Vector3 _offset;

    private void FixedUpdate()
    {
        Vector3 ballPosition = _ballTransform.position;
        transform.position = ballPosition + _offset;
    }
}
