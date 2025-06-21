using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f; // Speed of the player movement

    private PlayerControls playerControls; // Reference to the PlayerControls class
    private Vector2 movement; //movement of the player direction and speed
    private Rigidbody2D rb;

    // Start is called before the first frame update
    //Awake calles when the script instance is being loaded
    private void Awake()
    {
        playerControls = new PlayerControls(); // Initialize the PlayerControls instance
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component attached to the player
    }

    private void OnEnable()
    {
        playerControls.Enable(); // Enable the PlayerControls instance to start receiving input
    }

    // Update is called once per frame
    private void Update()
    {
        PlayerInput(); // Call the method to handle player input
    }

    private void FixedUpdate()
    {
        Move(); // Call the method to move the player based on input
    }

    private void PlayerInput()
    {
        // Get the movement input from the PlayerControls instance
        movement = playerControls.Movement.Move.ReadValue<Vector2>();
    }

    private void Move()
    {
        // Calculate the movement vector based on input and speed
        Vector2 moveDirection = movement * moveSpeed * Time.fixedDeltaTime;
        
        // Move the player by applying the movement vector to the Rigidbody2D
        rb.MovePosition(rb.position + moveDirection);
    }
}
