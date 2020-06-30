using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _smoothSpeed;

    private void Update()
    {
        Vector3 needlePosition = new Vector3(_player.position.x, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, needlePosition, _smoothSpeed);
    }
}
