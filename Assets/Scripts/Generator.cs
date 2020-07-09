using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private GridObject[] _templates;
    [SerializeField] private float _range;
    [SerializeField] private float _cellSize;
    [SerializeField] private Camera _camera;
    [SerializeField] private float _verticalOffset;

    private HashSet<Vector2Int> _engagedCells = new HashSet<Vector2Int>();

    private void Update()
    {
        FillRange(_player.position, _range);
        RemoveObjectsAbroadOfLeftScreenBorder(_camera);
    }

    private void FillRange(Vector2 center, float _range)
    {
        int cellsCountInRange = (int)(_range / _cellSize);
        Vector2Int _areaCenter = WorldToGridPosition(center);

        for (int i = -cellsCountInRange; i < cellsCountInRange; i++)
        {
            TryCreateGridObject(GridLayer.Ground, _areaCenter + new Vector2Int(i, 0));
            TryCreateGridObject(GridLayer.OnGround, _areaCenter + new Vector2Int(i, 0));
            TryCreateGridObject(GridLayer.InAir, _areaCenter + new Vector2Int(i, 0));
        }
    }

    private void RemoveObjectsAbroadOfLeftScreenBorder(Camera camera, float offset = 1)
    {
        float leftBorderCoordX = camera.transform.position.x - camera.orthographicSize * camera.aspect;

        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);

            if ((child.position.x + offset) < leftBorderCoordX)
                Destroy(child.gameObject);
        }
    }

    private void TryCreateGridObject(GridLayer layer, Vector2Int gridPosition)
    {
        gridPosition.y = (int)layer;

        if (_engagedCells.Contains(gridPosition))
            return;
        else
            _engagedCells.Add(gridPosition);

        if (!TryGetRandomTemplate(layer, out GridObject template))
            return;

        Vector2 position = GridToWorldPosition(gridPosition);
        Instantiate(template, GetOffsetPosition(position), Quaternion.identity, transform);
    }

    private Vector2 GetOffsetPosition(Vector2 position)
    {
        return new Vector2(position.x, position.y - _camera.orthographicSize + _verticalOffset);
    }

    private bool TryGetRandomTemplate(GridLayer layer, out GridObject template)
    {
        var variants = _templates.Where(item => item.Layer == layer);

        foreach (GridObject variant in variants)
        {
            if (variant.Chance > Random.Range(0, 100))
            {
                template = variant;
                return true;
            }
        }

        template = null;
        return false;
    }

    private Vector2 GridToWorldPosition(Vector2Int gridPosition)
    {
        return new Vector2(
            gridPosition.x * _cellSize,
            gridPosition.y * _cellSize);
    }

    private Vector2Int WorldToGridPosition(Vector2 worldPosition)
    {
        return new Vector2Int(
            (int)(worldPosition.x / _cellSize),
            (int)(worldPosition.y / _cellSize));
    }
}
