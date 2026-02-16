using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterInteraction : MonoBehaviour
{
    [SerializeField] Camera playerCamera;
    [SerializeField] private InputActionAsset playerControls;
    [SerializeField] private float interactionDistance;

    private CharacterController characterController;
    private InputAction interactionAction;

    IInteractable interactableTarget;
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        DontDestroyOnLoad(this);

        interactionAction = playerControls.FindActionMap("Player").FindAction("Interact");
    }
    private void OnEnable()
    {
        interactionAction.Enable();
    }
    private void OnDisable()
    {
        interactionAction.Disable();
    }
    void Update()
    {
        UpdateCurrentInteractable();
        CheckForInput();
    }
    private void UpdateCurrentInteractable()
    {
        var ray = playerCamera.ViewportPointToRay(new Vector2(0.5f, 0.5f));
        Physics.Raycast(ray, out var hit, interactionDistance);

        interactableTarget = hit.collider?.GetComponent<IInteractable>();
    }
    private void CheckForInput()
    {
        if (interactionAction.triggered && interactableTarget != null)
        {
            interactableTarget.Interact();
        }
    }
}
