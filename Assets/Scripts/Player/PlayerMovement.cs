using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    public float speed;


    private Vector2 movementVector;
    private Rigidbody rb;

    private void OnMove(InputValue inputValue)
    {
        movementVector = inputValue.Get<Vector2>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = transform.rotation * new Vector3(movementVector.x * speed, rb.linearVelocity.y, movementVector.y * speed);
    }
}
