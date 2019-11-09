using System;
using UnityEngine;

public class PlanetMovement : MonoBehaviour
{
    [SerializeField] private Transform Moon;
    [SerializeField] private float Speed = 10f;

    [SerializeField] private bool MoveCircular = true;
    [SerializeField] private float Tilt = 45f;

    private Action _move;

    // private float _radius;

    private void Start()
    {
        if (MoveCircular)
        {
            _move = CircularMovement;
        } else
        {
            _move = ElipsularMovement;
        }

        // _radius = (transform.position - Moon.position).magnitude;
    }

    private void Update()
    {
        _move();
    }

    private void CircularMovement()
    {
        var time = Time.deltaTime;
        var point = Moon.position;
        var axis = new Vector3(0, 0, 1);
        transform.RotateAround(point, axis, time * Speed);
    }

    float MCos(float value)
    {
        return Mathf.Cos(Mathf.Deg2Rad * value);
    }

    float MSin(float value)
    {
        return Mathf.Sin(Mathf.Deg2Rad * value);
    }

    private void ElipsularMovement()
    {
        var time = Time.time;

        transform.position = new Vector2(
            0f + (0.5f * MCos(time) * MCos(Tilt)) - (15f * MSin(time) * MSin(Tilt)),
            0f + (0.5f * MCos(time) * MSin(Tilt)) + (15f * MSin(time) * MCos(Tilt)));
    }
}