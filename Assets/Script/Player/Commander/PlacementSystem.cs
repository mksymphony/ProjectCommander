using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementSystem : MonoBehaviour
{
    [SerializeField] private GameObject _mouseIndicator;
    [SerializeField] private CommanderManager _inputManager;

    private void Awake()
    {
        if (!_inputManager)
        {
            Debug.LogError("InputManager 설정 필요");
        }
    }

    private void Update()
    {
        Vector3 mousePosition = _inputManager.GetSelectedMapPosition();
        _mouseIndicator.transform.position = mousePosition;
    }

}

