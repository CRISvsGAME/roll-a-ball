using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private int _count = 0;
    [SerializeField] private float _speed = 10f;
    private float _movementX;
    private float _movementY;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _rigidbody.AddForce(new Vector3(_movementX, 0f, _movementY) * _speed);
    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        _movementX = movementVector.x;
        _movementY = movementVector.y;
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject gameObject = other.gameObject;

        if (gameObject.CompareTag("PickUp"))
        {
            gameObject.SetActive(false);
            _count++;
            Debug.Log($"Count: {_count}");
        }
    }
}
