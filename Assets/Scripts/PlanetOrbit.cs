using UnityEngine;

public class PlanetOrbit : MonoBehaviour
{
    [SerializeField] private float Speed = 10f;
    
    //private float _xLocalPosition;
    private Vector3 _startPosition;

    private void Start()
    {
        // _xLocalPosition =  transform.GetChild(0).localPosition.x;
        _startPosition = transform.GetChild(0).localPosition;
    }

    private void Update()
    {
        var time = Time.deltaTime;
        var axis = new Vector3(0, 0, 1);

        transform.Rotate(axis, time * Speed);

        // transform.GetChild(0).localPosition = new Vector3(_xLocalPosition + (Mathf.Cos(time) * 2), 0 , 0);

        transform.GetChild(0).localPosition =
            _startPosition + Vector3.Slerp(Vector3.zero, Vector3.right * 15, time * 0.08f);
    }
}