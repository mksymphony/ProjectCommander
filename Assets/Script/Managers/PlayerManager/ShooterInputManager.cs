using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShooterInputManager : MonoBehaviour
{
    [SerializeField] private ShooterInput _input;
    [SerializeField] private Gun _gun;
    ShooterInput.ShooterMoveActions _sAction;
    private ShooterMotor _sMotor;
    private ShooterLook _sLook;

    private void Awake()
    {
        _input = new ShooterInput();
        _sAction = _input.ShooterMove;
        _sMotor = GetComponent<ShooterMotor>();
        _sLook = GetComponent<ShooterLook>();
        _sAction.Jump.performed += ctx => _sMotor.Jump();
        _sAction.Shoot.performed += ctx => _gun.Shoot();
    }
    private void FixedUpdate()
    {
        _sMotor.ProcessMove(_sAction.Movement.ReadValue<Vector2>());
    }
    private void LateUpdate()
    {
        _sLook.ProcessLook(_sAction.Look.ReadValue<Vector2>());
    }
    private void OnEnable()
    {
        _sAction.Enable();
    }
    private void OnDisable()
    {
        _sAction.Disable();
    }
}
