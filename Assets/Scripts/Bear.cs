using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bear : MonoBehaviour
{
    public InputManager InputManager;
    public Rigidbody2D Rigidbody2D;

    public float MaxVelocityMagnitude = 7.5f;
    public float JumpForceCoefficient = 1f;

    private Vector2 _startingPointerPosition;

    void Start()
    {
        InputManager.PointerDown += HandlePointerDown;
        InputManager.PointerUp += HandlePointerUp;
    }

    void FixedUpdate()
    {
        Rigidbody2D.velocity = Vector2.ClampMagnitude(Rigidbody2D.velocity, MaxVelocityMagnitude);
    }

    private void HandlePointerDown(Vector2 position)
    {
        _startingPointerPosition = position;
    }

    private void HandlePointerUp(Vector2 position)
    {
        var direction = (position - _startingPointerPosition);
        Jump(direction);
    }

    private void Jump(Vector2 direction)
    {
        ApplyForce(direction * JumpForceCoefficient);
    }

    public void ApplyForce(Vector2 force)
    {
        Rigidbody2D.AddForce(-force);
    }
}