using UnityEngine;
using System.Collections;

public class BallCollisionEffect : MonoBehaviour
{
    [SerializeField] private GameObject _collisionEffect;
    [SerializeField] private Color _collisionColor;
    [SerializeField] private float _compressionTime;

    private Renderer _renderer;
    private BallMovement _movement;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        _movement = GetComponent<BallMovement>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject collisionObject = collision.gameObject;
        if (collisionObject.tag == "Wall")
        {
            CreateParticles(collision.GetContact(0).point);
            _renderer.material.color = _collisionColor;
            StartCoroutine(Compression());
        }
    }

    private void CreateParticles(Vector3 position) =>
        Instantiate(_collisionEffect, position, Quaternion.identity);

    private IEnumerator Compression()
    {
        Vector3 scaleCompression = GetScaleCompression();
        Vector3 converseCompression = VectorExtensions.GetConverse(scaleCompression);
        Vector3 newScale = VectorExtensions.GetMultiplied(transform.localScale, converseCompression);
        
        transform.localScale = newScale;
        _renderer.material.color = _collisionColor;

        yield return new WaitForSeconds(_compressionTime);

        transform.localScale = Vector3.one;
        _renderer.material.color = Color.white;
    }

    private Vector3 GetScaleCompression()
    {
        Vector3 ballDirection = _movement.GetDirection();
        Vector3 scaleCompression = Vector3.one;

        if (ballDirection.x > ballDirection.z)
        {
            scaleCompression.x = 2f;
            return scaleCompression;
        }

        scaleCompression.z = 2f;
        return scaleCompression;
    }
}