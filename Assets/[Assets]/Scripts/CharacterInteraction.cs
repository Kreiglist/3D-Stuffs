// Peeps 2 thank
// Rytech
// Mr Bluecap
using UnityEngine;
public class CharacterInteraction : MonoBehaviour
{
    [SerializeField] Camera playerCamera;
    [SerializeField] private float interactionDistance;

    //private CharacterController characterController;
    IInteractable interactableTarget;
    private void Awake()
    {
        //characterController = GetComponent<CharacterController>();
        DontDestroyOnLoad(this);
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
        if (InputManager.instance.InteractInput && interactableTarget != null)
        {
            interactableTarget.Interact();
        }
    }
}
