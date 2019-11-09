using UnityEngine;

public class Bear : MonoBehaviour
{
    public InputManager InputManager;
    public Rigidbody2D Rigidbody2D;

    public float MaxVelocityMagnitude = 7.5f;
    public float JumpForceCoefficient = 1f;
    public GameObject Thruster;
    private Vector2 _startingPointerPosition;

    private Vector3 _lastPosition;

    void Start()
    {
        InputManager.PointerDown += HandlePointerDown;
        InputManager.PointerUp += HandlePointerUp;
    }

    void FixedUpdate()
    {
        Rigidbody2D.velocity = Vector2.ClampMagnitude(Rigidbody2D.velocity, MaxVelocityMagnitude);

        var moveDirection = transform.position - _lastPosition;

        if (moveDirection != Vector3.zero)
        {
            var angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle - 90f, Vector3.forward);
        }

        Thruster.SetActive(moveDirection.magnitude > 0.01f);
            
        _lastPosition = transform.position;
    }

    private void HandlePointerDown(Vector2 position)
    {
        _startingPointerPosition = position;
    }

    private void HandlePointerUp(Vector2 position)
    {
        var direction = (position - _startingPointerPosition);
        Jump(direction);
        GameManager.didShoot = true;
        Thruster.gameObject.SetActive(true);
    }

    private void Jump(Vector2 direction)
    {
        ApplyForce(direction * JumpForceCoefficient);
    }

    public void ApplyForce(Vector2 force)
    {
        Rigidbody2D.AddForce(-force);
        var moveDirection = transform.position - _lastPosition;
        Rigidbody2D.AddForce(moveDirection);

    }
}