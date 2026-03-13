// Peeps 2 thank
// Sasquatch B Gaming
// Dave/Game Development
// SpeedTutor
// PitiIT
using UnityEngine;
public class CharacterMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform transformCamera;
    [Header("Speed")]
    [SerializeField] private float speedWalk = 15f;
    //[SerializeField] private float speedSprint = 8f;
    //[SerializeField] private float speedCrouch = 3f;
    [Header("Gravity")]
    [SerializeField] private float gravity = -12f;
    [SerializeField] private float initialFallVelocity = -2f;

    private CharacterController characterController;
    private bool isGrounded;
    private float verticalVelocity;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }
    void Update()
    {
        isGrounded = characterController.isGrounded;
        HandleGravity();
        HandleMovement();
    }
    private void HandleMovement()
    {
        var move = transformCamera.TransformDirection(new Vector3(InputManager.instance.MoveInput.x, 0, InputManager.instance.MoveInput.y)).normalized;
        var currentSpeed = speedWalk;
        var finalMove = move * currentSpeed;
        finalMove.y = verticalVelocity;

        characterController.Move(finalMove * Time.deltaTime);
    }
    private void HandleGravity()
    {
        if (isGrounded && verticalVelocity < 0)
        {
            verticalVelocity = initialFallVelocity;
        }
        verticalVelocity += gravity * Time.deltaTime;
    }
}