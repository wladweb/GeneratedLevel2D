using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _smoothInterpolant;

    private void Update()
    {
        Vector3 targetPosition = new Vector3(_player.position.x, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, _smoothInterpolant);
    }
}
