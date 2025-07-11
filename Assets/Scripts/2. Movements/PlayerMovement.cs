using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;             // Movement speed
    public float jumpForce;             // Jump strength
    public float jumpCooldown;          // Cooldown time between jumps
    public float airMultiplier;         // Multiplier to reduce control in air
    bool readyToJump;                   // Flag to control jump cooldown

    [Header("Ground Check")]
    public float playerHeight;          // Height of the player used in ground detection
    public LayerMask whatIsGround;      // What layers count as ground
    bool grounded;                      // Is the player on the ground?

    [Header("Keybind")]
    public KeyCode jumpKey = KeyCode.Space; // Key used for jumping

    public float groundDrag;            // Drag applied when grounded

    public Transform orientation;       // Reference for movement direction

    float inputHorizontal;              // Horizontal input (A/D or Left/Right)
    float inputVertical;                // Vertical input (W/S or Up/Down)
    Vector3 moveDirection;              // Final direction to apply force to

    Rigidbody rb;                       // Rigidbody component for physics movement

    private void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get and configure the Rigidbody
        rb.freezeRotation = true; // Prevent rotation due to physics
        readyToJump = true; // Set this bool to true so the player can jump
    }

    private void Update()
    {
        // Check if the player is grounded using a raycast
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        MyInput();      // Get player input (movement & jump)
        SpeedControl(); // Clamp speed

        // Apply drag when grounded to slow down
        if (grounded) rb.linearDamping = groundDrag;
        else rb.linearDamping = 0;
    }

    private void FixedUpdate()
    {
        MovePlayer(); // Apply physics-based movement
    }

    private void MyInput()
    {
        // Get raw movement input
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");

        // Check for jump input
        if (Input.GetKey(jumpKey) && grounded && readyToJump)
        {
            readyToJump = false; // Disable further jumps
            Jump();              // Perform jump
            Invoke(nameof(ResetJump), jumpCooldown); // Re-enable jump after cooldown
        }
    }

    private void MovePlayer()
    {
        // Calculate direction based on orientation and input
        moveDirection = orientation.forward * inputVertical + orientation.right * inputHorizontal;

        // Apply movement force based on grounded or airborne state
        if (grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        }
        else
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
        }
    }

    private void SpeedControl()
    {
        // Get horizontal velocity (ignore vertical movement)
        Vector3 flatVel = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        // If the player is moving too fast, clamp speed to max
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.linearVelocity = new Vector3(limitedVel.x, rb.linearVelocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        // Reset vertical velocity to ensure consistent jump height
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        // Apply upward force to simulate a jump
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        // Allow jumping again
        readyToJump = true;
    }
}