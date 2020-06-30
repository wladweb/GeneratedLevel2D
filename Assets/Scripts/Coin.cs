using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
    private CoinsCollectSound _collectSound;

    public event UnityAction CoinCollected;

    private void OnEnable()
    {
        _collectSound = FindObjectOfType<CoinsCollectSound>();
        CoinCollected += _collectSound.OnCoinCollected;
    }

    private void OnDisable()
    {
        CoinCollected -= _collectSound.OnCoinCollected;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            player.AddCoin();
            CoinCollected?.Invoke();
            Destroy(gameObject);
        }
    }
}
