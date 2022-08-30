using System;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    private Rigidbody _rb;
    private Vector3 _direction;
    private Camera _camera;

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
        _direction = GetMousePosition() - transform.position;
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
        _rb.velocity = _direction * 100 * Time.deltaTime;
    }
}
