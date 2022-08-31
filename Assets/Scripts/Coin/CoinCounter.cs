using System;
using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    public static Action<float> OnCoinsIncreasing;

    private float _coins;

    public void IncreaseScore(float value)
    {
        _coins += value;
        OnCoinsIncreasing?.Invoke(value);
    }
}
