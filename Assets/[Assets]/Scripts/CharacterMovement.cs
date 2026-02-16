using UnityEngine;
using UnityEngine.InputSystem;
//using UnityEngine.UI;

public class CharacterMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform transformCamera;
    [SerializeField] private InputActionAsset playerControls;
    //[SerializeField] private Text speedDebug;
    [Header("Speed")]
    [SerializeField] private float speedWalk = 15f;
    //[SerializeField] private float speedSprint = 8f;
    //[SerializeField] private float speedCrouch = 3f;
    [Header("Gravity")]
    [SerializeField] private float gravity = -9.8f;
    [SerializeField] private float initialFallVelocity = -2f;

    private CharacterController characterController;
    private InputAction moveAction;
    private Vector2 moveInput;
    private bool isGrounded;
    private float verticalVelocity;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        DontDestroyOnLoad(this);

        moveAction = playerControls.FindActionMap("Player").FindAction("Move");
        moveAction.performed += context => moveInput = context.ReadValue<Vector2>();
        moveAction.canceled += context => moveInput = Vector2.zero;
    }
    private void OnEnable()
    {
        moveAction.Enable();
    }
    private void OnDisable()
    {
        moveAction.Disable();
    }
    void Update()
    {
        isGrounded = characterController.isGrounded;
        HandleGravity();
        HandleMovement();
    }
    private void HandleMovement()
    {
        var move = transformCamera.TransformDirection(new Vector3(moveInput.x, 0, moveInput.y)).normalized;
        var currentSpeed = speedWalk;
        var finalMove = move * currentSpeed;
        finalMove.y = verticalVelocity;

        //speedDebug.text = "Speed: " + finalMove.x.ToString();

        characterController.Move(finalMove * Time.deltaTime);
    }
    private void HandleGravity()
    {
        if (isGrounded && verticalVelocity < 0)
        {
            verticalVelocity = initialFallVelocity;
        }
        verticalVelocity = gravity * Time.deltaTime;
    }
}