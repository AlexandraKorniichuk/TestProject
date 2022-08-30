using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private float _force;

    private Vector3 _direction;
    private Rigidbody _rb;
    private Vector3 _firstMousePosition;
    private Camera _camera;

    private DirectionEffect _directionEffect;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _camera = Camera.main;
    }

    void FixedUpdate()
    {
        _rb.velocity += Physics.gravity * Time.fixedDeltaTime;
        float rigidbodyDrag = Mathf.Clamp01(1.0f - (_rb.drag * Time.fixedDeltaTime));
        _rb.velocity *= rigidbodyDrag;
        transform.position += _rb.velocity * Time.fixedDeltaTime;
    }

    private void OnMouseDown()
    {
        _firstMousePosition = GetMousePosition();
    }

    private void OnMouseDrag()
    {

    }

    private void OnMouseUp()
    {
        CalculateDirection();
        MoveBall();
    }

    private void CalculateDirection()
    {
        _direction = GetMousePosition() - _firstMousePosition;
        _direction.y = 0;
    }

    private Vector3 GetMousePosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 10;
        mousePosition = _camera.ScreenToWorldPoint(mousePosition);
        return mousePosition;
    }

    private void MoveBall()
    {
        _rb.velocity = _direction * _force;
    }

    public Vector3 GetDirection() => _direction;
}
