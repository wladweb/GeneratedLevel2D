using UnityEngine;
using System.Collections;
using UnityEngine.Events;

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
            StartCoroutine(_collectSound.Play(() => Destroy(gameObject)));
        }
    }

    private void Hide()
    {
        _renderer.color = new Color(0, 0, 0, 0);
    }
}

public static class AudioSourceExtension
{
    public static IEnumerator Play(this AudioSource audioSource, UnityAction callBack)
    {
        audioSource.Play();

        while (audioSource.isPlaying)
        {
            yield return null;
        }

        callBack();
    }
}
