using UnityEngine;

public class DragAndDrop3D : MonoBehaviour
{
    [SerializeField] private AudioClip[] pickupSFX;
    // Store the offset between the mouse position and the object's position
    Vector3 mousePosition;

    private Vector3 GetMousePos() // Converts the object's position from world coordinates to screen coordinates
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }

    private void OnMouseDown()  // Called when the user presses the mouse button while the cursor is over the object
    {
        // Calculate the offset between the mouse position and the object's position
        mousePosition = Input.mousePosition - GetMousePos();
        AudioManager.audioManager.PlayAudioRandom(pickupSFX, transform, 1f);
    }

    private void OnMouseDrag() // Called every frame while the user is dragging the object with the mouse
    {
        // Update the object's position based on the mouse movement, converting it back to world coordinates
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition);
    }
}
