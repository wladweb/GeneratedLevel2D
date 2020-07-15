using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class Coin : MonoBehaviour
{
    private AudioSource _collectSound;

    private void Start()
    {
        _collectSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            player.AddCoin();
            PlayCollectSound(() => Destroy(gameObject));
        }
    }

    private void PlayCollectSound(UnityAction callBack)
    {
        AudioSource.PlayClipAtPoint(_collectSound.clip, transform.position);
        callBack();
    }
}
