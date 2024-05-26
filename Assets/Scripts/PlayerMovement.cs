using UnityEngine;

public class DoomPlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Movement speed
    public float turnSpeed = 90f; // Turn speed in degrees per second

    private CharacterController controller; // Reference to the Character Controller

    void Start()
    {
        // Get the CharacterController component
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Get input for movement using WASD keys only
        float moveForwardBackward = 0f;
        float moveLeftRight = 0f;

        if (Input.GetKey(KeyCode.W))
        {
            moveForwardBackward = moveSpeed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            moveForwardBackward = -moveSpeed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            moveLeftRight = -moveSpeed;
        }
        else if (Input.GetKey(KeyCode.D))
        { 
            moveLeftRight = moveSpeed;
        }

        // Calculate movement direction
        Vector3 move = transform.forward * moveForwardBackward + transform.right * moveLeftRight;

        // Apply movement
        controller.SimpleMove(move);

        // Get input for turning using arrow keys (only affect rotation)
        float turn = 0f;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            turn = -turnSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            turn = turnSpeed * Time.deltaTime;
        }

        // Apply turning
        transform.Rotate(0, turn, 0);
    }
}
