using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private float _value;
    [SerializeField] private GameObject _pickingEffect;

    private void OnCollisionEnter(Collision collision)
    {
        GameObject collidedObject = collision.gameObject;
        CoinCounter coinCounter = collidedObject.GetComponent<CoinCounter>();

        if (coinCounter != null)
        {
            CreateEffects(collision.GetContact(0).point);
            coinCounter.IncreaseScore(_value);
            Destroy(gameObject);
        }
    }

    private void CreateEffects(Vector3 position) =>
        Instantiate(_pickingEffect, position, Quaternion.identity);
}
