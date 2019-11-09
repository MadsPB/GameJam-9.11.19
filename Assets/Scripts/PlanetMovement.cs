using System;
using UnityEngine;

public class PlanetMovement : MonoBehaviour
{
    [SerializeField] private Transform Moon;
    [SerializeField] private float Speed = 10f;

    [SerializeField] private bool MoveCircular = true;

    private Action _move;
    private float _radius;

    // Start is called before the first frame update
    private void Start()
    {
        if (MoveCircular)
        {
            _move = CircularMovement;
        } else
        {
            _move = ElipsularMovement;
        }

        _radius = (transform.position - Moon.position).magnitude;
    }

    // Update is called once per frame
    void Update()
    {
        _move();
    }

    private void CircularMovement()
    {
        var time = Time.deltaTime;
        var cos = Mathf.Cos(time);

        var point = Moon.position;
        var axis = new Vector3(0, 0, 1);
        transform.RotateAround(point, axis, time * Speed);
    }
    
    
   // public float alpha = 0f;

    public float tilt = 45f;

   

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
        var alpha = Time.time;
        
        transform.position = new Vector2(0f + (0.5f * MCos(alpha) * MCos(tilt)) - ( 15f * MSin(alpha) * MSin(tilt)),
                                         0f + (0.5f * MCos(alpha) * MSin(tilt)) + ( 15f * MSin(alpha) * MCos(tilt)));
      //  alpha += 5f;
    }
}