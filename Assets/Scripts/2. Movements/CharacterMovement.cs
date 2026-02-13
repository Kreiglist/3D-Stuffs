using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class CharacterMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform transformCamera;
    [SerializeField] private InputActionReference actionMove;
    [SerializeField] private Text speedDebug;
    [Header("Speed")]
    [SerializeField] private float speedWalk = 5f;
    //[SerializeField] private float speedSprint = 8f;
    //[SerializeField] private float speedCrouch = 3f;

    private CharacterController characterController;
    private Vector2 moveInput;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        DontDestroyOnLoad(this);
    }
    private void OnEnable()
    {
        actionMove.action.performed += StoreMovementInput;
        actionMove.action.canceled += StoreMovementInput;
    }
    private void OnDisable()
    {
        actionMove.action.performed -= StoreMovementInput;
        actionMove.action.canceled -= StoreMovementInput;
    }
    void Update()
    {
        HandleMovement();
    }
    private void StoreMovementInput(InputAction.CallbackContext callbackContext)
    {
        moveInput = callbackContext.ReadValue<Vector2>();
    }
    private void HandleMovement()
    {
        var move = transformCamera.TransformDirection(new Vector3(moveInput.x, 0, moveInput.y)).normalized;
        var currentSpeed = speedWalk;
        var finalMove = move * currentSpeed;

        speedDebug.text = "Speed: " + finalMove.x.ToString();

        characterController.Move(finalMove * Time.deltaTime);
    }
}
