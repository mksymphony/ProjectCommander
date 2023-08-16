using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementSystem : MonoBehaviour
{
    [SerializeField] private GameObject _mouseIndicator;
    [SerializeField] private GameObject _cellIndicator;

    [SerializeField] private CommanderManager _inputManager;
    [SerializeField] private Grid _grid;

    private void Awake()
    {
        if (!_inputManager)
        {
            Debug.LogError("InputManager ���� �ʿ�");
        }
    }

    private void Update()
    {
        Vector3 mousePosition = _inputManager.GetSelectedMapPosition();
        Vector3Int gridPosition = _grid.WorldToCell(mousePosition);

        _mouseIndicator.transform.position = mousePosition;
        _cellIndicator.transform.position = _grid.CellToWorld(gridPosition);
    }

}

