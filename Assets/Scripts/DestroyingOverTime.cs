using System.Collections;
using UnityEngine;

public class DestroyingOverTime : MonoBehaviour
{
    [SerializeField] private float _time;

    private void Start() =>
        StartCoroutine(WaitAndDestroy());

    private IEnumerator WaitAndDestroy()
    {
        yield return new WaitForSeconds(_time);
        Destroy(gameObject);
    }
}
