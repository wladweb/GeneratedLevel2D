using UnityEngine;
using TMPro;

public class CoinCountDisplayer : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _text;

    private void OnEnable()
    {
        _player.CoinsCountChanged += OnCoinCountChanged;
    }

    private void OnDisable()
    {
        _player.CoinsCountChanged -= OnCoinCountChanged;
    }

    private void OnCoinCountChanged(int count)
    {
        _text.text = count.ToString();
    }
}
