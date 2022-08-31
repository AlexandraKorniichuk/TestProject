using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CoinText : MonoBehaviour
{
    [SerializeField] private float _timeBetweenIncreasing;
    [SerializeField] private int _fontIncreasing;

    private Text _text;

    private void Start()
    {
        _text = GetComponent<Text>();
        _text.text = "0";
        CoinCounter.OnCoinsIncreasing += IncreaseCoins;
    }

    private void IncreaseCoins(float toAdd) =>
        StartCoroutine(IncreaseTextCoins(toAdd));

    private IEnumerator IncreaseTextCoins(float toAdd)
    {
        _text.fontSize += _fontIncreasing;
        int newCoins = int.Parse(_text.text) + 1;
        toAdd--;
        _text.text = newCoins.ToString();

        yield return new WaitForSeconds(_timeBetweenIncreasing);

        if(toAdd > 0)
            StartCoroutine(IncreaseTextCoins(toAdd));
        _text.fontSize -= _fontIncreasing;
    }
}
