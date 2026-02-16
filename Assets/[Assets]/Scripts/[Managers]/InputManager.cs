using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;

    public Vector2 MoveInput { get; private set; }
    public bool InteractInput { get; private set; }
    private PlayerInput playerInput;
    private InputAction moveAction;
    private InputAction interactAction;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        playerInput = GetComponent<PlayerInput>();
        SetupInputActions();
    }
    private void Update()
    {
        UpdateInputs();
    }

    private void SetupInputActions()
    {
        moveAction = playerInput.actions["Move"];
        interactAction = playerInput.actions["Interact"];
    }
    private void UpdateInputs()
    {
        MoveInput = moveAction.ReadValue<Vector2>();
        InteractInput = interactAction.WasPressedThisFrame();
    }
}
