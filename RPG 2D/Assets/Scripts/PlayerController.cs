using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f; // Speed of the player movement

    private PlayerControls playerControls; // Reference to the PlayerControls class
    private Rigidbody2D rb;
    private SpriteRenderer mySpriteRenderer;
    private Animator myAnimator;

    private Vector2 movement; //movement of the player direction and speed

    // Start is called before the first frame update
    //Awake calles when the script instance is being loaded
    private void Awake()
    {
        playerControls = new PlayerControls(); // Initialize the PlayerControls instance
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component attached to the player
        mySpriteRenderer = GetComponent<SpriteRenderer>(); // Get the SpriteRenderer component for visual representation
        myAnimator = GetComponent<Animator>(); // Get the Animator component for animations
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
        //AdjustPlayerFacingDirection(); // Adjust the player's facing direction based on mouse position
        Move(); // Call the method to move the player based on input
    }

    private void PlayerInput()
    {
        // Get the movement input from the PlayerControls instance
        movement = playerControls.Movement.Move.ReadValue<Vector2>();
        myAnimator.SetFloat("moveX", movement.x); // Set the horizontal movement parameter for the animator
        myAnimator.SetFloat("moveY", movement.y); // Set the vertical movement parameter for the animator
        if (movement.x < 0)
        {
            mySpriteRenderer.flipX = true; // Flip the sprite horizontally if moving left
        }
        else if (movement.x > 0)
        {
            mySpriteRenderer.flipX = false; // Do not flip the sprite if moving right
        }
    }

    private void Move()
    {
        // Calculate the movement vector based on input and speed
        Vector2 moveDirection = movement * moveSpeed * Time.fixedDeltaTime;
        
        // Move the player by applying the movement vector to the Rigidbody2D
        rb.MovePosition(rb.position + moveDirection);
    }

    //from the tutorial, but i dont like so i will not use it and make my own... but writing it here in case i need it inthe future and can't avoid it
    /*private void AdjustPlayerFacingDirection()
    {
        Vector3 mousePos = Input.mousePosition; // Get the mouse position in screen space
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(transform.position); // Convert player position to screen space
        if(mousePos.x < playerScreenPoint.x)
        {
            mySpriteRenderer.flipX = true; // Flip the sprite if the mouse is to the left of the player
        }
        else
        {
            mySpriteRenderer.flipX = false; // Do not flip the sprite if the mouse is to the right of the player
        }
    }*/
}
