using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CoinsCollectSound : MonoBehaviour
{
    private AudioSource _sound;

    private void Start()
    {
        _sound = GetComponent<AudioSource>();
    }

    public void OnCoinCollected()
    {
        _sound.Play();
    }
}
