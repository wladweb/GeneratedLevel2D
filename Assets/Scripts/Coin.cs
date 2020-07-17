using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(SpriteRenderer))]
public class Coin : MonoBehaviour
{
    private AudioSource _collectSound;
    private SpriteRenderer _renderer;

    private void Start()
    {
        _collectSound = GetComponent<AudioSource>();
        _renderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            player.AddCoin();
            Hide();
            _collectSound.Play();

            StartCoroutine(DestroyObjectByEndSound());
        }
    }

    private IEnumerator DestroyObjectByEndSound()
    {
        while (_collectSound.isPlaying)
        {
            yield return null;
        }

        Destroy(gameObject);
    }

    private void Hide()
    {
        _renderer.color = new Color(0, 0, 0, 0);
    }
}
