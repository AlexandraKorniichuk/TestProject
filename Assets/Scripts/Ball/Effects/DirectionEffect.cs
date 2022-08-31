using UnityEngine;

public class DirectionEffect : MonoBehaviour
{
    private LineRenderer _lineRenderer;
    private Vector3[] _points;

    private void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _points = new Vector3[2];
    }

    public void UpdateDirection(Vector3 newPosition)
    {
        _points[0] = transform.position;
        _points[1] = newPosition;

        for (int i = 0; i < _points.Length; i++)
        { 
            _lineRenderer.SetPosition(i, _points[i]);
        }
    }

    public void ClearEffects()
    {
        for (int i = 0; i < _points.Length; i++)
        {
            _lineRenderer.SetPosition(i, Vector3.zero);
        }
    }
}
