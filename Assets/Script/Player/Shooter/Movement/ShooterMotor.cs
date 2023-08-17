using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterMotor : MonoBehaviour
{
    private CharacterController _controller;
    private Vector3 _playerVelocity;

    private bool _isGrounded;

    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _jumpHight = 3f;
    private float _gravity = -9.8f;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }
    private void Update()
    {
        _isGrounded = _controller.isGrounded;
    }
    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;

        _controller.Move(transform.TransformDirection(moveDirection) * _speed * Time.deltaTime);

        _playerVelocity.y += _gravity * Time.deltaTime;
        if (_isGrounded && _playerVelocity.y < 0)
            _playerVelocity.y = -2f;
        _controller.Move(_playerVelocity * Time.deltaTime);
    }
    public void Jump()
    {
        if (_isGrounded)
        {
            _playerVelocity.y = Mathf.Sqrt(_jumpHight * -3.0f * _gravity);
        }
    }
}
